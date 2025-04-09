using Microsoft.Extensions.Logging;

namespace Trizen.DataLayer.Pattern;

public class UnitOfWork(TrizenDbContext dbContext, ILogger<UnitOfWork> logger) : IUnitOfWork, IDisposable
{
    private readonly TrizenDbContext _dbContext = dbContext;
    private readonly ILogger<UnitOfWork> _logger = logger;

    public async Task SaveChangesAsync()
    {
        try
        {
            _ = await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database Save Changes Exception({Exception}): {Message}", nameof(Exception), ex.Message);
            //throw new DatabaseFailException(ResponseMessage.CanNotSaveChanges);
        }
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}