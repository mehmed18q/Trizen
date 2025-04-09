using AutoMapper;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.Dto;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Services;

public class BaseEntityService(IBaseEntityRepository<Category> categoryRepository, IBaseEntityRepository<DestinationType> destinationTypeRepository, IBaseEntityRepository<TourType> tourTypeRepository, IUnitOfWork unitOfWork, IMapper mapper) : IBaseEntityService, IRegisterScoped
{
    private readonly IBaseEntityRepository<Category> _categoryRepository = categoryRepository;
    private readonly IBaseEntityRepository<DestinationType> _destinationTypeRepository = destinationTypeRepository;
    private readonly IBaseEntityRepository<TourType> _tourTypeRepository = tourTypeRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Response<bool>> CreateCategory(CreateBaseEntityDto dto)
    {
        try
        {
            Category entity = _mapper.Map<Category>(dto);
            _ = await _categoryRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(true);
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }

    public async Task<Response<bool>> CreateDestinationType(CreateBaseEntityDto dto)
    {
        try
        {
            DestinationType entity = _mapper.Map<DestinationType>(dto);
            _ = await _destinationTypeRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(true);
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }

    public async Task<Response<bool>> CreateTourType(CreateBaseEntityDto dto)
    {
        try
        {
            TourType entity = _mapper.Map<TourType>(dto);
            _ = await _tourTypeRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();

            return Response<bool>.SuccessResult(true);
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }

    public async Task<Response<bool>> DeleteCategory(int id)
    {
        if (await _categoryRepository.Any(id))
        {
            bool result = await _categoryRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return result ? Response<bool>.SuccessResult(result) : Response<bool>.FailResult(result);
        }

        return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.Category));
    }

    public async Task<Response<bool>> DeleteDestinationType(int id)
    {
        if (await _destinationTypeRepository.Any(id))
        {
            bool result = await _destinationTypeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return result ? Response<bool>.SuccessResult(result) : Response<bool>.FailResult(result);
        }

        return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.DestinationType));
    }

    public async Task<Response<bool>> DeleteTourType(int id)
    {
        if (await _tourTypeRepository.Any(id))
        {
            bool result = await _tourTypeRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return result ? Response<bool>.SuccessResult(result) : Response<bool>.FailResult(result);
        }

        return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.TourType));
    }

    public async Task<ListResponse<BaseEntityViewModel>> GetAllCategories()
    {
        List<Category> _entities = await _categoryRepository.GetAll();
        List<BaseEntityViewModel> entities = _mapper.Map<List<BaseEntityViewModel>>(_entities);
        return ListResponse<BaseEntityViewModel>.SuccessResult(entities);
    }

    public async Task<ListResponse<BaseEntityViewModel>> GetAllDestinationTypes()
    {
        List<DestinationType> _entities = await _destinationTypeRepository.GetAll();
        List<BaseEntityViewModel> entities = _mapper.Map<List<BaseEntityViewModel>>(_entities);
        return ListResponse<BaseEntityViewModel>.SuccessResult(entities);
    }

    public async Task<ListResponse<BaseEntityViewModel>> GetAllTourTypes()
    {
        List<TourType> _entities = await _tourTypeRepository.GetAll();
        List<BaseEntityViewModel> entities = _mapper.Map<List<BaseEntityViewModel>>(_entities);
        return ListResponse<BaseEntityViewModel>.SuccessResult(entities);
    }

    public async Task<Response<BaseEntityViewModel>> GetCategory(int id)
    {
        try
        {
            if (await _categoryRepository.Any(id))
            {
                Category? _result = await _categoryRepository.Get(id);
                BaseEntityViewModel result = _mapper.Map<BaseEntityViewModel>(_result);
                return Response<BaseEntityViewModel>.SuccessResult(result);
            }

            return Response<BaseEntityViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.Category));
        }
        catch (Exception) { }

        return Response<BaseEntityViewModel>.FailResult(null);
    }

    public async Task<Response<BaseEntityViewModel>> GetDestinationType(int id)
    {
        try
        {
            if (await _destinationTypeRepository.Any(id))
            {
                DestinationType? _result = await _destinationTypeRepository.Get(id);
                BaseEntityViewModel result = _mapper.Map<BaseEntityViewModel>(_result);
                return Response<BaseEntityViewModel>.SuccessResult(result);
            }

            return Response<BaseEntityViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.DestinationType));
        }
        catch (Exception) { }

        return Response<BaseEntityViewModel>.FailResult(null);
    }

    public async Task<Response<BaseEntityViewModel>> GetTourType(int id)
    {
        try
        {
            if (await _tourTypeRepository.Any(id))
            {
                TourType? _result = await _tourTypeRepository.Get(id);
                BaseEntityViewModel result = _mapper.Map<BaseEntityViewModel>(_result);
                return Response<BaseEntityViewModel>.SuccessResult(result);
            }

            return Response<BaseEntityViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.TourType));
        }
        catch (Exception) { }

        return Response<BaseEntityViewModel>.FailResult(null);
    }

    public async Task<Response<bool>> UpdateCategory(UpdateBaseEntityDto dto)
    {
        try
        {
            if (await _categoryRepository.Any(dto.Id))
            {
                Category entity = _mapper.Map<Category>(dto);
                await _categoryRepository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
                return Response<bool>.SuccessResult(true);
            }

            return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.TourType));
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }

    public async Task<Response<bool>> UpdateDestinationType(UpdateBaseEntityDto dto)
    {
        try
        {
            if (await _destinationTypeRepository.Any(dto.Id))
            {
                DestinationType entity = _mapper.Map<DestinationType>(dto);
                await _destinationTypeRepository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
                return Response<bool>.SuccessResult(true);
            }

            return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.TourType));
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }

    public async Task<Response<bool>> UpdateTourType(UpdateBaseEntityDto dto)
    {
        try
        {
            if (await _tourTypeRepository.Any(dto.Id))
            {
                TourType entity = _mapper.Map<TourType>(dto);
                await _tourTypeRepository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
                return Response<bool>.SuccessResult(true);
            }

            return Response<bool>.FailResult(false, Message.Format(Message.EntityNotFound, Resource.TourType));
        }
        catch (Exception) { }

        return Response<bool>.FailResult(false);
    }
}