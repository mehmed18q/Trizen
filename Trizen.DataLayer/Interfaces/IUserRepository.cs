using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer.Interfaces;

public interface IUserRepository
{
    Task<bool> AnyLikeTour(int userId, int tourId);
    Task<bool> AnyUser(string userName, string phoneNumber);
    Task<bool> AnyUser(int userId);
    Task<User?> GetUser(string userName, string password);
    Task<User?> GetUserById(int userId);
    Task Insert(User user);
    Task ObserveTour(TourObserve dto);
    Task Update(User user);
    Task UpdateTourObserve(TourObserve dto);
    Task<TourObserve?> GetTourObserve(TourObserve dto);
    Task<int> UserCounts();
    Task<int> ToursCounts();
    Task<int> DestinationsCounts();
    Task<int> TravelsCounts();
    Task<bool> AnyLikeDestination(int userId, int destinationId);
    Task<DestinationObserve?> GetDestinationObserve(DestinationObserve model);
    Task UpdateDestinationObserve(DestinationObserve observe);
    Task ObserveDestination(DestinationObserve model);
}