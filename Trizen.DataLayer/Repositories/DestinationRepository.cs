using Microsoft.EntityFrameworkCore;
using Trizen.Data.Destination.Dto;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class DestinationRepository(TrizenDbContext dbContext) : IDestinationRepository, IRepositoryScoped
{
    private readonly TrizenDbContext _dbContext = dbContext;

    public async Task<bool> Delete(int id)
    {
        Destination? destination = await Get(id);
        if (destination is not null)
        {
            try
            {
                _ = _dbContext.Remove(destination);
                return true;
            }
            catch (Exception) { }
        }

        return false;
    }

    public async Task<Destination?> Get(int id)
    {
        Destination? destination = await _dbContext.Destinations
            .Include(destination => destination.DestinationType)
            .Include(destination => destination.DestinationCategories)
            .FirstOrDefaultAsync(destination => destination.Id == id);

        return destination;
    }

    public async Task<List<Destination>> GetAll(SearchDestinationDto dto)
    {
        List<Destination> destination = await _dbContext.Destinations
            .Paging(dto.Pagination)
            .Include(destination => destination.DestinationType)
            .Include(destination => destination.DestinationCategories)
            .ToListAsync();

        return destination;
    }

    public async Task<int> Insert(Destination model)
    {
        _ = await _dbContext.AddAsync(model);

        return model.Id;
    }

    public async Task<bool> Any(int id)
    {
        bool exists = await _dbContext.Destinations.AnyAsync(destination => destination.Id == id);

        return exists;
    }

    public Task Update(Destination model)
    {
        _ = _dbContext.Update(model);

        return Task.CompletedTask;
    }

    public async Task<bool> AnyCategory(int id)
    {
        bool exists = await _dbContext.Categories.AnyAsync(category => category.Id == id);

        return exists;
    }
}