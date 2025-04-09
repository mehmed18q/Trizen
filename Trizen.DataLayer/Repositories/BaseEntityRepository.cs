using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;

namespace Trizen.DataLayer.Repositories;

internal class BaseEntityRepository<E>(TrizenDbContext dbContext) : IBaseEntityRepository<E> where E : BaseEntity
{
    private readonly DbSet<E> _dbSet = dbContext.Set<E>();

    public async Task<bool> Any(int id)
    {
        bool exists = await _dbSet.AnyAsync(entity => entity.Id == id);

        return exists;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            E? entity = await Get(id);
            if (entity is not null)
            {
                _ = _dbSet.Remove(entity);
            }
            return true;
        }
        catch (Exception) { }

        return false;
    }

    public async Task<E?> Get(int id)
    {
        E? entity = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);

        return entity;
    }

    public async Task<List<E>> GetAll()
    {
        List<E> entities = await _dbSet.ToListAsync();

        return entities;
    }

    public async Task<int> Insert(E model)
    {
        _ = await _dbSet.AddAsync(model);

        return model.Id;
    }

    public Task Update(E model)
    {
        _ = _dbSet.Update(model);

        return Task.CompletedTask;
    }
}