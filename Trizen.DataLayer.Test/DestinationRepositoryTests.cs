using Moq;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class DestinationRepositoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private DestinationRepository _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new DestinationRepository(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
