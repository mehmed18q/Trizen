using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class PersonalityRepository(TrizenDbContext dbContext) : IPersonalityRepository, IRepositoryScoped
{
    private readonly TrizenDbContext _dbContext = dbContext;

    public async Task<bool> Any(int personalityId)
    {
        bool exists = await _dbContext.Personalities.AnyAsync(personality => personality.Id == personalityId);
        return exists;
    }

    public async Task<bool> AnyCategory(int categoryId)
    {
        bool exists = await _dbContext.Categories.AnyAsync(ategory => ategory.Id == categoryId);
        return exists;
    }

    public async Task<bool> AnyDestinationType(int destinationTypeId)
    {
        bool exists = await _dbContext.DestinationTypes.AnyAsync(personality => personality.Id == destinationTypeId);
        return exists;
    }

    public async Task<bool> AnyTourType(int tourTypeId)
    {
        bool exists = await _dbContext.TourTypes.AnyAsync(tourType => tourType.Id == tourTypeId);
        return exists;
    }

    public async Task<List<Personality>> GetAll()
    {
        List<Personality> personalities = await _dbContext.Personalities.ToListAsync();
        return personalities;
    }

    public async Task<Personality?> Get(int personalityId)
    {
        Personality? personality = await _dbContext.Personalities.FirstOrDefaultAsync(personality => personality.Id == personalityId);
        return personality;
    }

    public async Task<List<int>> GetAllCategories(int personalityId)
    {
        List<int> personality = await _dbContext.PersonalityCategories.Where(personality => personality.PersonalityId == personalityId).Select(s => s.CategoryId).ToListAsync();
        return personality ?? [];
    }

    public async Task<List<int>> GetAllDestinationTypes(int personalityId)
    {
        List<int> personality = await _dbContext.PersonalityDestinationTypes.Where(personality => personality.PersonalityId == personalityId).Select(s => s.DestinationTypeId).ToListAsync();
        return personality ?? [];
    }

    public async Task<List<int>> GetAllTourTypes(int personalityId)
    {
        List<int> personality = await _dbContext.PersonalityTourTypes.Where(personality => personality.PersonalityId == personalityId).Select(s => s.TourTypeId).ToListAsync();
        return personality ?? [];
    }

    public Task Update(Personality personality)
    {
        _ = _dbContext.Update(personality);
        return Task.CompletedTask;
    }
}