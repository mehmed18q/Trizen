
using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface IPersonalityRepository
{
    Task<bool> Any(int personalityId);
    Task<bool> AnyCategory(int category);
    Task<bool> AnyDestinationType(int destinationType);
    Task<bool> AnyTourType(int tourType);
    Task<Personality?> Get(int personalityId);
    Task<List<Personality>> GetAll();
    Task<List<int>> GetAllCategories(int personalityId);
    Task<List<int>> GetAllDestinationTypes(int personalityId);
    Task<List<int>> GetAllTourTypes(int personalityId);
    Task Update(Personality personality);
}