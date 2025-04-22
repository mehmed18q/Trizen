using Microsoft.EntityFrameworkCore;
using Trizen.Data.Base.Dto;
using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;
using Trizen.Recommendation.Services;

namespace Trizen.DataLayer.Repositories;

internal class TourRepository(TrizenDbContext dbContext, ITouRecommendation touRecommendation) : ITourRepository, IRegisterRepositories
{
    private readonly TrizenDbContext _dbContext = dbContext;
    private readonly ITouRecommendation _touRecommendation = touRecommendation;

    public async Task<bool> Delete(int id)
    {
        Tour? tour = await Get(id);
        if (tour is not null)
        {
            try
            {
                _ = _dbContext.Remove(tour);
                return true;
            }
            catch (Exception) { }
        }

        return false;
    }

    public async Task<Tour?> Get(int id)
    {
        Tour? tour = await _dbContext.Tours
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationCategories).ThenInclude(destinationCategory => destinationCategory.Category)
            .Include(tour => tour.TourType)
            .Include(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(tour => tour.TourObserves)
            .FirstOrDefaultAsync(tour => tour.Id == id);

        return tour;
    }

    public async Task<List<Tour>> GetAll(SearchTourDto dto)
    {
        List<Tour> tour = await _dbContext.Tours
            .Paging(dto.Pagination)
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationCategories).ThenInclude(destinationCategory => destinationCategory.Category)
            .Include(tour => tour.TourType)
            .Include(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(tour => tour.TourObserves)
            .ToListAsync();

        return tour;
    }

    public async Task<List<Tour>> Search(SearchTourViewModel dto)
    {
        List<Tour> tour = await _dbContext.Tours
            .If(dto.Title.IsNotEmpty(), query => query.Where(tour => tour.Title.Contains(dto.Title!) || (tour.Description != null && tour.Description.Contains(dto.Title!)) || tour.Destination.Title.Contains(dto.Title!) || (tour.Destination.Description != null && tour.Destination.Description.Contains(dto.Title!))))
            .If(dto.DestinationId.IsNotZeroOrNull(), query => query.Where(tour => tour.DestinationId == dto.DestinationId))
            .If(dto.TourTypeId.IsNotZeroOrNull(), query => query.Where(tour => tour.TourTypeId == dto.TourTypeId))
            .If(dto.DestinationTypeId.IsNotZeroOrNull(), query => query.Where(tour => tour.Destination.DestinationTypeId == dto.DestinationTypeId))
            .If(dto.CategoryId.IsNotZeroOrNull(), query => query.Where(tour => tour.Destination.DestinationCategories.Any(destinationCategory => destinationCategory.CategoryId == dto.CategoryId)))
            .If(dto.GoDate.HasValue, query => query.Where(tour => DateTime.Compare(tour.StartTime.Date, dto.GoDate!.Value) == 0))
            .If(dto.BackDate.HasValue, query => query.Where(tour => DateTime.Compare(tour.EndTime.Date, dto.BackDate!.Value) == 0))
            .Paging(dto.Pagination)
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationCategories).ThenInclude(destinationCategory => destinationCategory.Category)
            .Include(tour => tour.TourType)
            .Include(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
            .Include(tour => tour.TourObserves)
            .ToListAsync();

        return tour;
    }

    public async Task<int> Insert(Tour model)
    {
        _ = await _dbContext.AddAsync(model);

        return model.Id;
    }

    public async Task<bool> Any(int id)
    {
        bool exists = await _dbContext.Tours.AnyAsync(tour => tour.Id == id);

        return exists;
    }

    public async Task<bool> AnyWithCapacity(int id, int capacity)
    {
        bool exists = await _dbContext.Tours.AnyAsync(tour => tour.Id == id && (capacity - tour.Travels.Sum(travel => travel.Passengers.Count)) > 0);
        return exists;
    }

    public Task Update(Tour model)
    {
        _ = _dbContext.Update(model);

        return Task.CompletedTask;
    }

    public async Task<bool> AnyCategory(int categoryId)
    {
        bool exists = await _dbContext.Categories.AnyAsync(category => category.Id == categoryId);

        return exists;
    }

    public async Task<List<Tour>> GetFavoriteTours(int userId)
    {
        List<Tour> observedTours = await _dbContext.TourObserves.Where(tourObserve => tourObserve.ObserverUserId == userId && tourObserve.ObserveType == ObserveType.Like)
            .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
            .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourType)
            .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
            .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourObserves)
            .Select(tourObserve => tourObserve.Tour).ToListAsync();

        return observedTours;
    }

    public async Task<List<Tour>> GetMyTours(int userId)
    {
        List<Tour> observedTours = await _dbContext.Travels.Where(travel => travel.UserId == userId || travel.Passengers.Any(passenger => passenger.PassengerUserId == userId))
                .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
                .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourType)
                .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
                .Include(tourObserve => tourObserve.Tour).ThenInclude(tour => tour.TourObserves)
                .Select(tourObserve => tourObserve.Tour).ToListAsync();

        return observedTours;
    }

    public async Task<List<EntityObject<Tour, float>>> GetRecommendedTours(int userId, int take = 10)
    {
        List<TourScoreDto> recommendedTours = await _touRecommendation.GetRecommendedTours(userId, take);
        IEnumerable<int> recommendedToursId = recommendedTours.Select(recommendedTour => recommendedTour.TourId);

        List<Tour> _tours = await _dbContext.Tours
                    .Include(tour => tour.Destination).ThenInclude(destination => destination.DestinationType)
                    .Include(tour => tour.TourType)
                    .Include(tour => tour.TourCategories).ThenInclude(tourCategory => tourCategory.Category)
                    .Include(tour => tour.Travels).ThenInclude(travel => travel.Passengers)
                    .Include(tour => tour.TourObserves)
                    .Where(tour => recommendedToursId.Contains(tour.Id))
                    .ToListAsync();

        List<EntityObject<Tour, float>> tours = _tours
                    .Select(tour => new EntityObject<Tour, float>
                    {
                        Entity = tour,
                        Value = recommendedTours.First(recommendedTour => recommendedTour.TourId == tour.Id).Score
                    })
                    .ToList();

        return tours;
    }

    public async Task<bool> CheckHaveTravel(int userId)
    {
        bool haveTour = await _dbContext.Travels.AnyAsync(travel => travel.Status == TravelStatus.Paid && (travel.UserId == userId || travel.Passengers.Any(passenger => passenger.PassengerUserId == userId)));

        return haveTour;
    }

    public async Task<List<Destination>> GetFavoriteDestinations(int userId)
    {
        List<Destination> observedDestinations = await _dbContext.DestinationObserves.Where(destinationObserve => destinationObserve.ObserverUserId == userId && destinationObserve.ObserveType == ObserveType.Like)
        .Include(destinationObserve => destinationObserve.Destination).ThenInclude(destination => destination.DestinationType)
        .Include(destinationObserve => destinationObserve.Destination)
        .Include(destinationObserve => destinationObserve.Destination).ThenInclude(destinationObserve => destinationObserve.DestinationCategories).ThenInclude(tourCategory => tourCategory.Category)
        .Include(destinationObserve => destinationObserve.Destination).ThenInclude(destination => destination.DestinationObserves)
        .Select(destinationObserve => destinationObserve.Destination).ToListAsync();

        return observedDestinations;
    }
}