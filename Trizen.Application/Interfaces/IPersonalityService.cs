using Trizen.Data.Tour.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface IPersonalityService
{
    Task<ListResponse<int>> GetAllCategories(int personalityId);
    Task<ListResponse<int>> GetAllTourTypes(int personalityId);
    Task<ListResponse<int>> GetAllDestinationTypes(int personalityId);
    Task<PersonalityViewModel> GetPersonality(int id);
    Task<Response<bool>> PersonalityCategoryInsertUpdate(UpdatePersonalityDto dto);
    Task<Response<bool>> PersonalityDestinationTypeInsertUpdate(UpdatePersonalityDto dto);
    Task<Response<bool>> PersonalityTourTypeInsertUpdate(UpdatePersonalityDto dto);
    Task<List<PersonalityViewModel>> GetPersonalities();
}
