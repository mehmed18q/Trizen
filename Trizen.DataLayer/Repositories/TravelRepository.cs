using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class TravelRepository(TrizenDbContext dbContext) : ITravelRepository, IRegisterRepositories
{
    private readonly TrizenDbContext _dbContext = dbContext;

    public async Task<bool> Any(int travelId)
    {
        bool exists = await _dbContext.Travels.AnyAsync(travel => travel.Id == travelId);

        return exists;
    }

    public async Task<Travel?> Get(int travelId)
    {
        Travel? travel = await _dbContext.Travels
                    .Include(travel => travel.Passengers).ThenInclude(passengers => passengers.User)
                .Include(travel => travel.Tour)
    .Include(travel => travel.Tour).ThenInclude(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourObserves)
                    .Include(travel => travel.User)
                    .FirstOrDefaultAsync(travel => travel.Id == travelId);

        return travel;
    }

    public async Task<Travel?> GetOnProcessTravel(int userId, int tourId)
    {
        Travel? travel = await _dbContext.Travels
                    .Include(travel => travel.Passengers).ThenInclude(passengers => passengers.User)
.Include(travel => travel.Tour)
.Include(travel => travel.Tour).ThenInclude(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourObserves).Include(travel => travel.User)
                    .FirstOrDefaultAsync(travel => travel.TraveledTourId == tourId && travel.UserId == userId && travel.Status == TravelStatus.Processing);

        return travel;
    }

    public async Task<List<Travel>> GetUserBasket(int userId)
    {
        List<Travel> travels = await _dbContext.Travels
            .Include(travel => travel.Passengers).ThenInclude(passengers => passengers.User)
            .Include(travel => travel.Tour)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourType)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(travel => travel.Tour).ThenInclude(tour => tour.TourObserves).Include(travel => travel.User)
            .Where(travel => travel.UserId == userId && travel.Status == TravelStatus.Processing).ToListAsync();

        return travels;
    }

    public async Task<int> Insert(Travel travel)
    {
        _ = await _dbContext.AddAsync(travel);

        return travel.Id;
    }

    public Task Update(Travel travel)
    {
        _ = _dbContext.Update(travel);

        return Task.CompletedTask;
    }
}

