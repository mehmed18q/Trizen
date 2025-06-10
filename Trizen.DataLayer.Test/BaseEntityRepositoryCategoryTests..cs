using Moq;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Repositories;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class BaseEntityRepositoryCategoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;

    private BaseEntityRepository<Category> _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _service = new BaseEntityRepository<Category>(_contextMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
