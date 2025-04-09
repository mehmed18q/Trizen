using Trizen.Data.Base.ViewModel;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Application.Interfaces;

public interface IListService
{
    Task<ListResponse<ListViewModel>> Destinations(int? destinationId = null);
    Task<ListResponse<ListViewModel>> TourTypes(int? tourTypeId = null);
    Task<ListResponse<ListViewModel>> Categories(int? categoryId = null);
    Task<ListResponse<ListViewModel>> Personalities(int? personalityId = null);
    Task<ListResponse<ListViewModel>> DestinationTypes(int? destinationTypeId = null);
    ListResponse<ListViewModel> GeographicalLocations(GeographicalLocation? geographicalLocationId = null);
    Task<ListResponse<ListViewModel>> GetUsers();
}
