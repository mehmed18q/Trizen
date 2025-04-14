using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class UserRepository(TrizenDbContext dbContext) : IUserRepository, IRegisterRepositories
{
    private readonly TrizenDbContext _dbContext = dbContext;

    public async Task<bool> AnyLikeTour(int userId, int tourId)
    {
        bool exists = await _dbContext.TourObserves.AnyAsync(tourObserve => tourObserve.ObserverUserId == userId && tourObserve.ObservedTourId == tourId && tourObserve.ObserveType == ObserveType.Like);

        return exists;
    }

    public async Task<bool> AnyLikeDestination(int userId, int destinationId)
    {
        bool exists = await _dbContext.DestinationObserves.AnyAsync(destinationObserve => destinationObserve.ObserverUserId == userId && destinationObserve.ObservedDestinationId == destinationId && destinationObserve.ObserveType == ObserveType.Like);

        return exists;
    }


    public async Task<bool> AnyUser(string userName, string phoneNumber)
    {
        bool exists = await _dbContext.Users.AnyAsync(user => user.UserName == userName || user.PhoneNumber == phoneNumber);

        return exists;
    }

    public async Task<bool> AnyUser(int userId)
    {
        bool exists = await _dbContext.Users.AnyAsync(user => user.Id == userId);

        return exists;
    }

    public async Task<User?> GetUser(string userName, string password)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == userName && user.Password == password);

        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        User? user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);

        return user;
    }

    public async Task Insert(User user)
    {
        _ = await _dbContext.Users.AddAsync(user);
    }

    public async Task ObserveTour(TourObserve dto)
    {
        _ = await _dbContext.TourObserves.AddAsync(dto);
    }

    public async Task ObserveDestination(DestinationObserve dto)
    {
        _ = await _dbContext.DestinationObserves.AddAsync(dto);
    }

    public async Task<TourObserve?> GetTourObserve(TourObserve dto)
    {
        TourObserve? observe = await _dbContext.TourObserves.FirstOrDefaultAsync(tourObserve => tourObserve.ObserverUserId == dto.ObserverUserId && tourObserve.ObservedTourId == dto.ObservedTourId && tourObserve.ObserveType == dto.ObserveType);
        return observe;
    }

    public async Task<DestinationObserve?> GetDestinationObserve(DestinationObserve dto)
    {
        DestinationObserve? observe = await _dbContext.DestinationObserves.FirstOrDefaultAsync(destinationObserve => destinationObserve.ObserverUserId == dto.ObserverUserId && destinationObserve.ObservedDestinationId == dto.ObservedDestinationId && destinationObserve.ObserveType == dto.ObserveType);
        return observe;
    }

    public Task Update(User user)
    {
        _ = _dbContext.Users.Update(user);

        return Task.CompletedTask;
    }

    public Task UpdateTourObserve(TourObserve dto)
    {
        _ = _dbContext.TourObserves.Update(dto);

        return Task.CompletedTask;
    }

    public Task UpdateDestinationObserve(DestinationObserve dto)
    {
        _ = _dbContext.DestinationObserves.Update(dto);

        return Task.CompletedTask;
    }

    public async Task<int> UserCounts()
    {
        return await _dbContext.Users.CountAsync();
    }

    public async Task<int> ToursCounts()
    {
        return await _dbContext.Tours.CountAsync();
    }

    public async Task<int> DestinationsCounts()
    {
        return await _dbContext.Destinations.CountAsync();
    }

    public async Task<int> TravelsCounts()
    {
        return await _dbContext.Travels.CountAsync(travel => travel.Status == TravelStatus.Paid);
    }
}

