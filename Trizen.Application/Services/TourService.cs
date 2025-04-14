using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Trizen.Application.Interfaces;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;
using Trizen.Infrastructure.Utilities;

namespace Trizen.Application.Services;

internal class TourService(ITourRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : ITourService, IRegisterServices
{
    private readonly ITourRepository _repository = repository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<bool>> Create(CreateTourDto dto)
    {
        Tour tour = _mapper.Map<Tour>(dto);
        if (dto.UploadImage is not null)
        {
            Response<string> newImage = await FileUtility.UploadFileLocal(new UploadFileDto
            {
                Entity = nameof(Tour),
                File = dto.UploadImage,
            });

            if (newImage.IsSuccess && tour.Image.IsNotEmpty())
            {
                _ = FileUtility.DeleteFileLocal(new DeleteFileDto
                {
                    Entity = nameof(Tour),
                    FileName = tour.Image!
                });
            }

            if (newImage.IsSuccess)
            {
                tour.Image = newImage.Data;
            }
        }

        _ = await _repository.Insert(tour);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.SuccessResult(tour.Id.IsNotZeroOrNull());
    }

    public async Task<Response<bool>> TourCategoryInsertUpdate(CategoryTourDto dto)
    {
        if (await _repository.Any(dto.TourId))
        {
            Tour? tour = await _repository.Get(dto.TourId);
            IEnumerable<int> _tourCategories = dto.TourCategories?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int category in _tourCategories)
            {
                if (await _repository.AnyCategory(category) && !tour!.TourCategories.Any(tourCategory => tourCategory.CategoryId == category))
                {
                    tour.TourCategories.Add(new TourCategory
                    {
                        CategoryId = category,
                        TourId = tour.Id,
                    });
                }
            }

            IEnumerable<TourCategory> deletes = tour!.TourCategories.Where(tourCategory => !_tourCategories.Contains(tourCategory.CategoryId));
            foreach (TourCategory? item in deletes)
            {
                _ = tour.TourCategories.Remove(item);
            }

            await _repository.Update(tour);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.SuccessResult(true);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Tour));
    }

    public async Task<Response<bool>> Delete(int id)
    {
        if (await _repository.Any(id))
        {
            bool result = await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(result);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Tour));
    }

    public async Task<Response<TourViewModel>> Get(int id, int userId = 0)
    {
        Tour? result = await _repository.Get(id);
        if (result is not null)
        {
            TourViewModel tour = _mapper.Map<TourViewModel>(result);
            tour.Destination.Categories = _mapper.Map<List<DestinationCategoryViewModel>>(result.Destination.DestinationCategories);
            tour.Liked = result.TourObserves.Any(tourObserve => tourObserve.ObserverUserId == userId && tourObserve.ObserveType == ObserveType.Like);

            return Response<TourViewModel>.SuccessResult(tour);
        }

        return Response<TourViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.Tour));
    }

    public async Task<ListResponse<TourViewModel>> GetAll(SearchTourDto dto)
    {
        List<Tour> result = await _repository.GetAll(dto);
        dto.Pagination.TotalCount = result.Count;
        List<TourViewModel> tours = MapTours(result, dto.UserId);
        return ListResponse<TourViewModel>.SuccessResult(tours, null, dto.Pagination);
    }

    public async Task<ListResponse<TourViewModel>> Search(SearchTourViewModel dto)
    {
        dto.GoDate = dto.GoDate.ToGregorian();
        dto.BackDate = dto.BackDate.ToGregorian();
        List<Tour> result = await _repository.Search(dto);
        dto.Pagination.TotalCount = result.Count;
        List<TourViewModel> tours = MapTours(result, dto.UserId);

        return ListResponse<TourViewModel>.SuccessResult(tours, null, dto.Pagination);
    }

    public async Task<Response<bool>> Update(UpdateTourDto dto)
    {
        if (await _repository.Any(dto.Id))
        {
            Tour? tour = await _repository.Get(dto.Id);

            tour = _mapper.Map(dto, tour!);
            if (dto.UploadImage is not null)
            {
                Response<string> newImage = await FileUtility.UploadFileLocal(new UploadFileDto
                {
                    Entity = nameof(Tour),
                    File = dto.UploadImage,
                });

                if (newImage.IsSuccess && tour.Image.IsNotEmpty())
                {
                    _ = FileUtility.DeleteFileLocal(new DeleteFileDto
                    {
                        Entity = nameof(Tour),
                        FileName = tour.Image!
                    });
                }

                if (newImage.IsSuccess)
                {
                    tour.Image = newImage.Data;
                }
            }

            await _repository.Update(tour);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(tour.Id.IsNotZeroOrNull());
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Tour));
    }


    private List<TourViewModel> MapTours(List<Tour> tours, int userId)
    {
        List<TourViewModel> result = tours.Select(tour => new TourViewModel
        {
            Title = tour.Title,
            DaysCount = tour.DaysCount,
            Description = tour.Description,
            Destination = _mapper.Map<DestinationViewModel>(tour.Destination),
            Categories = _mapper.Map<List<TourCategoryViewModel>>(tour.TourCategories),
            DestinationId = tour.DestinationId,
            EndTime = tour.EndTime,
            Id = tour.Id,
            Image = $"/Images/Tour/{tour.Image}",
            MaximumAge = tour.MaximumAge,
            MaximumPassenger = tour.MaximumPassenger,
            MinimumAge = tour.MinimumAge,
            Price = tour.Price,
            SleepNightsCount = tour.SleepNightsCount,
            StartTime = tour.StartTime,
            TourTypeId = tour.TourTypeId,
            TourTypeTitle = tour.TourType.Title,
            Liked = tour.TourObserves.Any(tourObserve => tourObserve.ObserverUserId == userId && tourObserve.ObserveType == ObserveType.Like),
            Capacity = tour.MaximumPassenger - tour.Travels.Sum(travel => travel.Passengers.Count),
        }).ToList();

        return result;
    }

    public async Task<ListResponse<TourViewModel>> GetFavoriteTours(int userId)
    {
        List<Tour> result = await _repository.GetFavoriteTours(userId);
        List<TourViewModel> tours = _mapper.Map<List<TourViewModel>>(result);

        return ListResponse<TourViewModel>.SuccessResult(tours);
    }

    public async Task<ListResponse<TourViewModel>> GetMyTours(int userId)
    {
        List<Tour> result = await _repository.GetMyTours(userId);
        List<TourViewModel> tours = _mapper.Map<List<TourViewModel>>(result);

        return ListResponse<TourViewModel>.SuccessResult(tours);
    }

    public async Task<ListResponse<TourViewModel>> GetSuggestedTours(int userId)
    {
        List<Tour> _tours = await _repository.GetRecommendedTours(userId);
        List<TourViewModel> tours = MapTours(_tours, userId);

        return ListResponse<TourViewModel>.SuccessResult(tours);
    }
}
