using Moq;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class ListRepositoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private ListRepository _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new ListRepository(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
