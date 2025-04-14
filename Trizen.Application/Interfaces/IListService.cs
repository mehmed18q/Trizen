using Trizen.Data.Base.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface IListService
{
    Task<ListResponse<ListViewModel>> Destinations(int? destinationId = null);
    Task<ListResponse<ListViewModel>> TourTypes(int? tourTypeId = null);
    Task<ListResponse<ListViewModel>> Categories(int? categoryId = null);
    Task<ListResponse<ListViewModel>> Personalities(int? personalityId = null);
    Task<ListResponse<ListViewModel>> DestinationTypes(int? destinationTypeId = null);
    Task<ListResponse<ListViewModel>> GetUsers();
    ListResponse<ListViewModel> UserGenders(int? gendersId = null);
}
