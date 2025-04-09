using Trizen.Data.Base.Dto;
using Trizen.Data.Base.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface IBaseEntityService
{
    Task<Response<bool>> CreateTourType(CreateBaseEntityDto dto);
    Task<Response<bool>> UpdateTourType(UpdateBaseEntityDto dto);
    Task<Response<bool>> DeleteTourType(int id);
    Task<Response<BaseEntityViewModel>> GetTourType(int id);
    Task<ListResponse<BaseEntityViewModel>> GetAllTourTypes();

    Task<Response<bool>> CreateDestinationType(CreateBaseEntityDto dto);
    Task<Response<bool>> UpdateDestinationType(UpdateBaseEntityDto dto);
    Task<Response<bool>> DeleteDestinationType(int id);
    Task<Response<BaseEntityViewModel>> GetDestinationType(int id);
    Task<ListResponse<BaseEntityViewModel>> GetAllDestinationTypes();

    Task<Response<bool>> CreateCategory(CreateBaseEntityDto dto);
    Task<Response<bool>> UpdateCategory(UpdateBaseEntityDto dto);
    Task<Response<bool>> DeleteCategory(int id);
    Task<Response<BaseEntityViewModel>> GetCategory(int id);
    Task<ListResponse<BaseEntityViewModel>> GetAllCategories();
}
