using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface IListRepository
{
    Task<List<Category>> GetCategories();
    Task<List<Destination>> GetDestinations();
    Task<List<TourType>> GetTourTypes();
    Task<List<Personality>> GetPersonalities();
    Task<List<DestinationType>> GetDestinationTypes();
    Task<List<User>> GetUsers();
}