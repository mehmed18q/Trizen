using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface ITravelRepository
{
    Task<bool> Any(int travelId);
    Task<Travel?> Get(int travelId);
    Task<Travel?> GetOnProcessTravel(int userId, int tourId);
    Task<List<Travel>> GetUserBasket(int userId);
    Task<int> Insert(Travel travel);
    Task Update(Travel travel);
}