using Moq;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class BaseEntityRepositoryTourTypeTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private BaseEntityRepository<TourType> _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new BaseEntityRepository<TourType>(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
