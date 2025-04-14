using Trizen.Application.Interfaces;
using Trizen.Data.Tour.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Services;

public class PersonalityService(IPersonalityRepository repository, IUnitOfWork unitOfWork) : IPersonalityService, IRegisterServices
{
    private readonly IPersonalityRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ListResponse<int>> GetAllCategories(int personalityId)
    {
        List<int> entities = await _repository.GetAllCategories(personalityId);
        return ListResponse<int>.SuccessResult(entities);
    }

    public async Task<ListResponse<int>> GetAllDestinationTypes(int personalityId)
    {
        List<int> entities = await _repository.GetAllDestinationTypes(personalityId);
        return ListResponse<int>.SuccessResult(entities);
    }

    public async Task<ListResponse<int>> GetAllTourTypes(int personalityId)
    {
        List<int> entities = await _repository.GetAllTourTypes(personalityId);
        return ListResponse<int>.SuccessResult(entities);
    }

    public async Task<PersonalityViewModel> GetPersonality(int id)
    {
        Personality? Personality = await _repository.Get(id);
        return new PersonalityViewModel
        {
            Code = Personality!.Code,
            Title = Personality.Title,
            Description = Personality.Description,
            Id = Personality.Id
        };
    }

    public async Task<List<PersonalityViewModel>> GetPersonalities()
    {
        List<Personality> Personalities = await _repository.GetAll();
        return Personalities.Select(Personality => new PersonalityViewModel
        {
            Code = Personality!.Code,
            Title = Personality.Title,
            Description = Personality.Description,
            Id = Personality.Id
        }).ToList();
    }

    public async Task<Response<bool>> PersonalityCategoryInsertUpdate(UpdatePersonalityDto dto)
    {
        if (await _repository.Any(dto.PersonalityId))
        {
            Personality? personality = await _repository.Get(dto.PersonalityId);

            IEnumerable<int> _personalityCategories = dto.EntitieIds?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int category in _personalityCategories)
            {
                if (await _repository.AnyCategory(category) && !personality.PersonalityCategories.Any(personalityCategory => personalityCategory.CategoryId == category))
                {
                    personality.PersonalityCategories.Add(new PersonalityCategory
                    {
                        CategoryId = category,
                        PersonalityId = personality.Id,
                    });
                }
            }

            IEnumerable<PersonalityCategory> deletes = personality.PersonalityCategories.Where(personalityCategory => !_personalityCategories.Contains(personalityCategory.CategoryId));
            foreach (PersonalityCategory? item in deletes)
            {
                _ = personality.PersonalityCategories.Remove(item);
            }

            personality.Title = dto.Title;
            personality.Code = dto.Code;
            personality.Description = dto.Description;
            await _repository.Update(personality);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.SuccessResult(true);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Personality));
    }

    public async Task<Response<bool>> PersonalityDestinationTypeInsertUpdate(UpdatePersonalityDto dto)
    {
        if (await _repository.Any(dto.PersonalityId))
        {
            Personality? personality = await _repository.Get(dto.PersonalityId);

            IEnumerable<int> _personalityDestinationTypes = dto.EntitieIds?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int destinationType in _personalityDestinationTypes)
            {
                if (await _repository.AnyDestinationType(destinationType) && !personality.PersonalityDestinationTypes.Any(personalityDestinationType => personalityDestinationType.DestinationTypeId == destinationType))
                {
                    personality.PersonalityDestinationTypes.Add(new PersonalityDestinationType
                    {
                        DestinationTypeId = destinationType,
                        PersonalityId = personality.Id,
                    });
                }
            }

            IEnumerable<PersonalityDestinationType> deletes = personality.PersonalityDestinationTypes.Where(personalityDestinationType => !_personalityDestinationTypes.Contains(personalityDestinationType.DestinationTypeId));
            foreach (PersonalityDestinationType? item in deletes)
            {
                _ = personality.PersonalityDestinationTypes.Remove(item);
            }

            await _repository.Update(personality);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.SuccessResult(true);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Personality));
    }

    public async Task<Response<bool>> PersonalityTourTypeInsertUpdate(UpdatePersonalityDto dto)
    {
        if (await _repository.Any(dto.PersonalityId))
        {
            Personality? personality = await _repository.Get(dto.PersonalityId);

            IEnumerable<int> _personalityTourTypes = dto.EntitieIds?.Split(',')?.Select(int.Parse) ?? [];
            foreach (int tourType in _personalityTourTypes)
            {
                if (await _repository.AnyTourType(tourType) && !personality.PersonalityTourTypes.Any(personalityTourType => personalityTourType.TourTypeId == tourType))
                {
                    personality.PersonalityTourTypes.Add(new PersonalityTourType
                    {
                        TourTypeId = tourType,
                        PersonalityId = personality.Id,
                    });
                }
            }

            IEnumerable<PersonalityTourType> deletes = personality.PersonalityTourTypes.Where(personalityTourType => !_personalityTourTypes.Contains(personalityTourType.TourTypeId));
            foreach (PersonalityTourType? item in deletes)
            {
                _ = personality.PersonalityTourTypes.Remove(item);
            }

            await _repository.Update(personality);
            await _unitOfWork.SaveChangesAsync();
            return Response<bool>.SuccessResult(true);
        }

        return Response<bool>.SuccessResult(false, Message.Format(Message.EntityNotFound, Resource.Personality));
    }
}