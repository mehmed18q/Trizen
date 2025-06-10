using AutoMapper;
using Moq;
using Trizen.Application.Services;
using Trizen.Data.Travel.Dto;
using Trizen.Data.Travel.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.Application.Test
{
    [TestFixture]
    public class TravelServiceTests
    {
        private Mock<ITravelRepository> _travelRepoMock = null!;
        private Mock<IUserRepository> _userRepoMock = null!;
        private Mock<ITourRepository> _tourRepoMock = null!;
        private Mock<IUnitOfWork> _unitOfWorkMock = null!;
        private Mock<IMapper> _mapperMock = null!;
        private TravelService _service = null!;

        [SetUp]
        public void SetUp()
        {
            _travelRepoMock = new Mock<ITravelRepository>();
            _userRepoMock = new Mock<IUserRepository>();
            _tourRepoMock = new Mock<ITourRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _service = new TravelService(_travelRepoMock.Object, _unitOfWorkMock.Object, _mapperMock.Object, _userRepoMock.Object, _tourRepoMock.Object);
        }

        [Test]
        public async Task Create_ShouldReturnExisting_WhenOnProcessTravelExists()
        {
            CreateTravelDto dto = new() { UserId = 1, TourId = 2 };
            Travel existing = new() { Id = 5 };
            BasketViewModel basket = new();

            _ = _travelRepoMock.Setup(x => x.GetOnProcessTravel(dto.UserId, dto.TourId)).ReturnsAsync(existing);
            _ = _travelRepoMock.Setup(x => x.Get(existing.Id)).ReturnsAsync(existing);
            _ = _mapperMock.Setup(x => x.Map<BasketViewModel>(It.IsAny<Travel>())).Returns(basket);

            Response<BasketViewModel> result = await _service.Create(dto);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(basket));
        }

        [Test]
        public async Task Create_ShouldInsert_WhenHasCapacity()
        {
            CreateTravelDto dto = new() { UserId = 1, TourId = 2 };
            Travel travel = new() { Id = 3, Passengers = [] };
            BasketViewModel basket = new();

            _ = _travelRepoMock.Setup(x => x.GetOnProcessTravel(dto.UserId, dto.TourId)).ReturnsAsync((Travel?)null);
            _ = _tourRepoMock.Setup(x => x.AnyWithCapacity(dto.TourId, 1)).ReturnsAsync(true);
            _ = _mapperMock.Setup(x => x.Map<Travel>(dto)).Returns(travel);
            _ = _travelRepoMock.Setup(x => x.Insert(travel)).ReturnsAsync(travel.Id);
            _ = _travelRepoMock.Setup(x => x.Get(travel.Id)).ReturnsAsync(travel);
            _ = _mapperMock.Setup(x => x.Map<BasketViewModel>(travel)).Returns(basket);

            Response<BasketViewModel> result = await _service.Create(dto);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(basket));
        }

        [Test]
        public async Task Create_ShouldFail_WhenNoCapacity()
        {
            CreateTravelDto dto = new() { UserId = 1, TourId = 2 };

            _ = _travelRepoMock.Setup(x => x.GetOnProcessTravel(dto.UserId, dto.TourId)).ReturnsAsync((Travel?)null);
            _ = _tourRepoMock.Setup(x => x.AnyWithCapacity(dto.TourId, 1)).ReturnsAsync(false);
            _ = _tourRepoMock.Setup(x => x.Any(dto.TourId)).ReturnsAsync(false);

            Response<BasketViewModel> result = await _service.Create(dto);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Message, Does.Contain("ظرفیت"));
        }

        [Test]
        public async Task Get_ShouldReturnMappedResult()
        {
            Travel travel = new() { Id = 1 };
            BasketViewModel view = new();
            _ = _travelRepoMock.Setup(x => x.Get(1)).ReturnsAsync(travel);
            _ = _mapperMock.Setup(x => x.Map<BasketViewModel>(travel)).Returns(view);

            Response<BasketViewModel> result = await _service.Get(1);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(view));
        }

        [Test]
        public async Task TravelPassengerInsertUpdate_ShouldUpdateCorrectly()
        {
            PassengerTravelDto dto = new() { TravelId = 1, TravelPassengers = "2,3" };
            Travel travel = new()
            {
                Id = 1,
                Tour = new Tour { Price = 100, Title = "Tour100" },
                Passengers = [new Passenger { PassengerUserId = 4 }]
            };

            _ = _travelRepoMock.Setup(x => x.Any(dto.TravelId)).ReturnsAsync(true);
            _ = _travelRepoMock.Setup(x => x.Get(dto.TravelId)).ReturnsAsync(travel);
            _ = _userRepoMock.Setup(x => x.AnyUser(It.IsAny<int>())).ReturnsAsync(true);

            Response<double> result = await _service.TravelPassengerInsertUpdate(dto);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(200));
        }

        [Test]
        public async Task TravelPassengerInsertUpdate_ShouldReturnZero_WhenTravelNotExists()
        {
            _ = _travelRepoMock.Setup(x => x.Any(1)).ReturnsAsync(false);

            Response<double> result = await _service.TravelPassengerInsertUpdate(new PassengerTravelDto { TravelId = 1 });

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(0));
        }

        [Test]
        public async Task GetUserBasket_ShouldReturnMappedList()
        {
            List<Travel> list = [new Travel(), new Travel()];
            List<BasketViewModel> mapped = [new(), new()];

            _ = _travelRepoMock.Setup(x => x.GetUserBasket(1)).ReturnsAsync(list);
            _ = _mapperMock.Setup(x => x.Map<List<BasketViewModel>>(list)).Returns(mapped);

            ListResponse<BasketViewModel> result = await _service.GetUserBasket(1);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Data, Is.EqualTo(mapped));
        }

        [Test]
        public async Task Pay_ShouldUpdateStatusAndChargeWallet()
        {
            Travel travel = new()
            {
                Id = 1,
                Tour = new Tour { Price = 100, Title = "Tour100" },
                Passengers = [new(), new()],
                UserId = 1
            };

            _ = _travelRepoMock.Setup(x => x.Get(travel.Id)).ReturnsAsync(travel);

            Response<bool> result = await _service.Pay(travel.Id);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(travel.Status, Is.EqualTo(TravelStatus.Paid));
        }

        [Test]
        public async Task Cancel_ShouldRefundIfPaid()
        {
            Travel travel = new()
            {
                Id = 1,
                Tour = new Tour { Price = 100, Title = "Tour100" },
                Passengers = [new(), new()],
                UserId = 1,
                Status = TravelStatus.Paid
            };

            _ = _travelRepoMock.Setup(x => x.Get(travel.Id)).ReturnsAsync(travel);

            Response<bool> result = await _service.Cancel(travel.Id);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(travel.Status, Is.EqualTo(TravelStatus.Cancelled));
        }
    }
}
