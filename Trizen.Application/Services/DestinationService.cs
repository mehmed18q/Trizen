using AutoMapper;
using Trizen.Application.Interfaces;
using Trizen.Data.Destination.Dto;
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

internal class DestinationService(IDestinationRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : IDestinationService, IRegisterServices
{
    private readonly IDestinationRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<bool>> Create(CreateDestinationDto dto)
    {
        Destination destination = _mapper.Map<Destination>(dto);
        if (dto.UploadImage is not null)
        {
            Response<string> newImage = await FileUtility.UploadFileLocal(new UploadFileDto
            {
                Entity = nameof(Destination),
                File = dto.UploadImage,
            });

            if (newImage.IsSuccess && destination.Image.IsNotEmpty())
            {
                _ = FileUtility.DeleteFileLocal(new DeleteFileDto
                {
                    Entity = nameof(Destination),
                    FileName = destination.Image!
                });
            }

            if (newImage.IsSuccess)
            {
                destination.Image = newImage.Data;
            }
        }

        _ = await _repository.Insert(destination);
        await _unitOfWork.SaveChangesAsync();

        return Response<bool>.SuccessResult(destination.Id.IsNotZeroOrNull());
    }

    public async Task<Response<bool>> Delete(int id)
    {
        if (await _repository.Any(id))
        {
            bool result = await _repository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(result);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    public async Task<Response<bool>> DestinationCategoryInsertUpdate(CategoryDestinationDto dto)
    {
        if (await _repository.Any(dto.DestinationId))
        {
            Destination? destination = await _repository.Get(dto.DestinationId);
            IEnumerable<int> _destinationCategories = dto.DestinationCategories?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int category in _destinationCategories)
            {
                if (await _repository.AnyCategory(category) && !destination.DestinationCategories.Any(destinationCategory => destinationCategory.CategoryId == category))
                {
                    destination.DestinationCategories.Add(new DestinationCategory
                    {
                        CategoryId = category,
                        DestinationId = destination.Id,
                    });
                }
            }

            IEnumerable<DestinationCategory> deletes = destination.DestinationCategories.Where(destinationCategory => !_destinationCategories.Contains(destinationCategory.CategoryId));
            foreach (DestinationCategory? item in deletes)
            {
                _ = destination.DestinationCategories.Remove(item);
            }

            await _repository.Update(destination);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.SuccessResult(true);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    public async Task<Response<DestinationViewModel>> Get(int id)
    {
        Destination? result = await _repository.Get(id);
        if (result is not null)
        {
            DestinationViewModel destination = _mapper.Map<DestinationViewModel>(result);
            destination.Categories = _mapper.Map<List<DestinationCategoryViewModel>>(result.DestinationCategories);
            return Response<DestinationViewModel>.SuccessResult(destination);
        }

        return Response<DestinationViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    public async Task<ListResponse<DestinationViewModel>> GetAll(SearchDestinationDto dto)
    {
        List<Destination> result = await _repository.GetAll(dto);
        List<DestinationViewModel> destinations = MapDestinations(result, dto.UserId);
        return ListResponse<DestinationViewModel>.SuccessResult(destinations);
    }

    public async Task<ListResponse<DestinationViewModel>> GetFavoriteDestinations(int userId)
    {
        List<Destination> result = await _repository.GetFavoriteDestinations(userId);
        List<DestinationViewModel> destinations = _mapper.Map<List<DestinationViewModel>>(result);

        return ListResponse<DestinationViewModel>.SuccessResult(destinations);
    }

    public async Task<Response<DestinationViewModel>> GetById(int id, int userId)
    {
        Destination? result = await _repository.Get(id);
        if (result is not null)
        {
            DestinationViewModel destination = _mapper.Map<DestinationViewModel>(result);
            destination.Categories = _mapper.Map<List<DestinationCategoryViewModel>>(result.DestinationCategories);
            destination.Liked = result.DestinationObserves.Any(destinationObserve => destinationObserve.ObserverUserId == userId && destinationObserve.ObserveType == ObserveType.Like);
            destination.ToursCount = result.Tours.Count;

            return Response<DestinationViewModel>.SuccessResult(destination);
        }

        return Response<DestinationViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    public async Task<Response<bool>> Update(UpdateDestinationDto dto)
    {
        if (await _repository.Any(dto.Id))
        {
            Destination? destination = await _repository.Get(dto.Id);

            destination = _mapper.Map(dto, destination!);
            if (dto.UploadImage is not null)
            {
                Response<string> newImage = await FileUtility.UploadFileLocal(new UploadFileDto
                {
                    Entity = nameof(Destination),
                    File = dto.UploadImage,
                });

                if (newImage.IsSuccess && destination.Image.IsNotEmpty())
                {
                    _ = FileUtility.DeleteFileLocal(new DeleteFileDto
                    {
                        Entity = nameof(Destination),
                        FileName = destination.Image!
                    });
                }

                if (newImage.IsSuccess)
                {
                    destination.Image = newImage.Data;
                }
            }

            await _repository.Update(destination);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(destination.Id.IsNotZeroOrNull());
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    private List<DestinationViewModel> MapDestinations(List<Destination> destinations, int userId)
    {
        List<DestinationViewModel> result = destinations.Select(destination => new DestinationViewModel
        {
            Title = destination.Title,
            Description = destination.Description,
            Categories = _mapper.Map<List<DestinationCategoryViewModel>>(destination.DestinationCategories),
            Id = destination.Id,
            Image = $"/Images/Destination/{destination.Image}",
            DestinationTypeId = destination.DestinationTypeId,
            DestinationTypeTitle = destination.DestinationType.Title,
            Liked = destination.DestinationObserves.Any(tourObserve => tourObserve.ObserverUserId == userId && tourObserve.ObserveType == ObserveType.Like),
            ToursCount = destination.Tours.Count
        }).ToList();

        return result;
    }
}
