using Trizen.Data.Destination.Dto;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.Tour.Dto;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface IDestinationService
{
    Task<Response<bool>> Create(CreateDestinationDto dto);
    Task<Response<bool>> Update(UpdateDestinationDto dto);
    Task<Response<bool>> Delete(int id);
    Task<Response<bool>> DestinationCategoryInsertUpdate(CategoryDestinationDto dto);
    Task<Response<DestinationViewModel>> Get(int id);
    Task<ListResponse<DestinationViewModel>> GetAll(SearchDestinationDto dto);
    Task<Response<DestinationViewModel>> GetById(int id, int userId);
    Task<ListResponse<DestinationViewModel>> GetFavoriteDestinations(int userId);
}
