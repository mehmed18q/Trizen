using Trizen.Data.Destination.Dto;
using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface IDestinationRepository
{
    Task<int> Insert(Destination model);
    Task Update(Destination model);
    Task<bool> Delete(int id);
    Task<bool> Any(int id);
    Task<Destination?> Get(int id);
    Task<List<Destination>> GetAll(SearchDestinationDto dto);
    Task<bool> AnyCategory(int category);
}