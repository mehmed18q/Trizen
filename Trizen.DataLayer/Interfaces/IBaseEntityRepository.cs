namespace Trizen.DataLayer.Interfaces;

public interface IBaseEntityRepository<E>
{
    Task<int> Insert(E model);
    Task Update(E model);
    Task<bool> Delete(int id);
    Task<bool> Any(int id);
    Task<E?> Get(int id);
    Task<List<E>> GetAll();
}