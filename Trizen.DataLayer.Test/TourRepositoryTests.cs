using Moq;
using Trizen.DataLayer.Repositories;
using Trizen.Recommendation.Services;

namespace Trizen.DataLayer.Test;

[TestFixture]
public class TourRepositoryTests
{
    private Mock<TrizenDbContext> _contextMock = null!;
    private Mock<ITouRecommendation> _touRecommendationMock = null!;

    private TourRepository _service = null!;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<TrizenDbContext>();
        _touRecommendationMock = new Mock<ITouRecommendation>();
        _service = new TourRepository(_contextMock.Object, _touRecommendationMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _contextMock.Reset();
    }
}
