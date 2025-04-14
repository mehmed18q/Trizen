using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class ListRepository(TrizenDbContext dbContext) : IListRepository, IRegisterRepositories
{
    private readonly TrizenDbContext _dbContext = dbContext;

    public async Task<List<Category>> GetCategories()
    {
        List<Category> categories = await _dbContext.Categories.ToListAsync();

        return categories;
    }

    public async Task<List<Destination>> GetDestinations()
    {
        List<Destination> destinations = await _dbContext.Destinations.ToListAsync();

        return destinations;
    }

    public async Task<List<DestinationType>> GetDestinationTypes()
    {
        List<DestinationType> destinationType = await _dbContext.DestinationTypes.ToListAsync();

        return destinationType;
    }

    public async Task<List<Personality>> GetPersonalities()
    {
        List<Personality> personalities = await _dbContext.Personalities.ToListAsync();

        return personalities;
    }

    public async Task<List<TourType>> GetTourTypes()
    {
        List<TourType> tourTypes = await _dbContext.TourTypes.ToListAsync();

        return tourTypes;
    }

    public async Task<List<User>> GetUsers()
    {
        List<User> users = await _dbContext.Users.ToListAsync();

        return users;
    }
}