namespace Trizen.DataLayer.Pattern;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
