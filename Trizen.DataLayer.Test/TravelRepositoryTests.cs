using Moq;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class TravelRepositoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private TravelRepository _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new TravelRepository(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
