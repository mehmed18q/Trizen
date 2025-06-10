using Moq;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class UserRepositoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private UserRepository _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new UserRepository(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
