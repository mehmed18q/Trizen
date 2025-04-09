using AutoMapper;
using Trizen.Application.Interfaces;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Services;

internal class ListService(IListRepository repository, IMapper mapper) : IListService, IRegisterScoped
{
    private readonly IListRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ListResponse<ListViewModel>> Categories(int? categoryId = null)
    {
        List<Category> _categories = await _repository.GetCategories();
        List<ListViewModel> categories = _mapper.Map<List<ListViewModel>>(_categories);
        categories.ForEach(categoty => { categoty.IsSelected = categoty.Id == categoryId; });
        return ListResponse<ListViewModel>.SuccessResult(categories);
    }

    public async Task<ListResponse<ListViewModel>> Destinations(int? destinationId = null)
    {
        List<Destination> _destinations = await _repository.GetDestinations();
        List<ListViewModel> destinations = _mapper.Map<List<ListViewModel>>(_destinations);
        destinations.ForEach(destination => { destination.IsSelected = destination.Id == destinationId; });
        return ListResponse<ListViewModel>.SuccessResult(destinations);
    }

    public async Task<ListResponse<ListViewModel>> DestinationTypes(int? destinationTypeId = null)
    {
        List<DestinationType> _destinationTypes = await _repository.GetDestinationTypes();
        List<ListViewModel> destinationType = _mapper.Map<List<ListViewModel>>(_destinationTypes);
        destinationType.ForEach(personality => { personality.IsSelected = personality.Id == destinationTypeId; });
        return ListResponse<ListViewModel>.SuccessResult(destinationType);
    }

    public ListResponse<ListViewModel> GeographicalLocations(GeographicalLocation? geographicalLocationId = null)
    {
        IEnumerable<GeographicalLocation> _geographicalLocations = EnumerationExtension.GetEnumList<GeographicalLocation>();
        List<ListViewModel> geographicalLocations = _geographicalLocations.Select(geographicalLocation => new ListViewModel
        {
            Id = geographicalLocation.ToInt(),
            Title = geographicalLocation.GetDisplayName(),
            IsSelected = geographicalLocation == geographicalLocationId
        }).ToList();

        return ListResponse<ListViewModel>.SuccessResult(geographicalLocations);
    }

    public async Task<ListResponse<ListViewModel>> GetUsers()
    {
        List<User> _users = await _repository.GetUsers();
        List<ListViewModel> users = _mapper.Map<List<ListViewModel>>(_users);
        return ListResponse<ListViewModel>.SuccessResult(users);
    }

    public async Task<ListResponse<ListViewModel>> Personalities(int? personalityId)
    {
        List<Personality> _personalities = await _repository.GetPersonalities();
        List<ListViewModel> personalities = _mapper.Map<List<ListViewModel>>(_personalities);
        personalities.ForEach(personality => { personality.IsSelected = personality.Id == personalityId; });
        return ListResponse<ListViewModel>.SuccessResult(personalities);
    }

    public async Task<ListResponse<ListViewModel>> TourTypes(int? tourTypeId = null)
    {
        List<TourType> _tourTypes = await _repository.GetTourTypes();
        List<ListViewModel> tourTypes = _mapper.Map<List<ListViewModel>>(_tourTypes);
        tourTypes.ForEach(tourType => { tourType.IsSelected = tourType.Id == tourTypeId; });
        return ListResponse<ListViewModel>.SuccessResult(tourTypes);
    }
}
