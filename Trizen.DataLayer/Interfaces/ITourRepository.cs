using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface ITourRepository
{
    Task<int> Insert(Tour model);
    Task Update(Tour model);
    Task<bool> Delete(int id);
    Task<bool> Any(int id);
    Task<bool> AnyCategory(int categoryId);
    Task<Tour?> Get(int id);
    Task<List<Tour>> GetAll(SearchTourDto dto);
    Task<List<Tour>> Search(SearchTourViewModel dto);
    Task<List<Tour>> GetFavoriteTours(int userId);
    Task<List<Tour>> GetMyTours(int userId);
    Task<bool> AnyWithCapacity(int tourId, int capacity);
    Task<List<Tour>> GetSuggestedTours(int userId);
    Task<bool> CheckHaveTravel(int userId);
}