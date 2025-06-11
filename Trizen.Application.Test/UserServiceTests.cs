using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using Trizen.Application.Services;
using Trizen.Data.User.Dto;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Test;

[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private Mock<ITourRepository> _tourRepositoryMock;
    private Mock<IDestinationRepository> _destinationRepositoryMock;
    private Mock<IUnitOfWork> _unitOfWorkMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IFileUtility> _fileUtilityMock;
    private Mock<IOptions<TrizenConfiguration>> _optionsMock;

    private UserService _service;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _tourRepositoryMock = new Mock<ITourRepository>();
        _destinationRepositoryMock = new Mock<IDestinationRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _fileUtilityMock = new Mock<IFileUtility>();
        _optionsMock = new Mock<IOptions<TrizenConfiguration>>();
        _ = _optionsMock.Setup(o => o.Value).Returns(new TrizenConfiguration());

        _service = new UserService(
            _userRepositoryMock.Object,
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _optionsMock.Object,
            _tourRepositoryMock.Object,
            _destinationRepositoryMock.Object,
            _fileUtilityMock.Object
        );
    }

    [Test]
    public async Task LikeTour_TourExists_NotPreviouslyLiked_ShouldAddLike()
    {
        // Arrange
        LikeTourDto dto = new() { UserId = 1, TourId = 2 };

        _ = _tourRepositoryMock.Setup(r => r.Any(dto.TourId)).ReturnsAsync(true);
        _ = _userRepositoryMock.Setup(r => r.AnyLikeTour(dto.UserId, dto.TourId)).ReturnsAsync(false);

        TourObserve tourObserve = new();
        _ = _mapperMock.Setup(m => m.Map<TourObserve>(dto)).Returns(tourObserve);

        // Act
        Response<string> result = await _service.LikeTour(dto);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        _userRepositoryMock.Verify(r => r.ObserveTour(It.IsAny<TourObserve>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task LikeTour_TourExists_PreviouslyLiked_ShouldUpdateToVisit()
    {
        // Arrange
        LikeTourDto dto = new() { UserId = 1, TourId = 2 };
        TourObserve observe = new() { ObserveType = ObserveType.Like };

        _ = _tourRepositoryMock.Setup(r => r.Any(dto.TourId)).ReturnsAsync(true);
        _ = _userRepositoryMock.Setup(r => r.AnyLikeTour(dto.UserId, dto.TourId)).ReturnsAsync(true);
        _ = _mapperMock.Setup(m => m.Map<TourObserve>(dto)).Returns(observe);
        _ = _userRepositoryMock.Setup(r => r.GetTourObserve(observe)).ReturnsAsync(observe);

        // Act
        Response<string> result = await _service.LikeTour(dto);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        _userRepositoryMock.Verify(r => r.UpdateTourObserve(It.Is<TourObserve>(o => o.ObserveType == ObserveType.Visit)), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task LikeTour_TourDoesNotExist_ShouldFail()
    {
        // Arrange
        LikeTourDto dto = new() { UserId = 1, TourId = 999 };

        _ = _tourRepositoryMock.Setup(r => r.Any(dto.TourId)).ReturnsAsync(false);

        // Act
        Response<string> result = await _service.LikeTour(dto);

        // Assert
        Assert.That(result.IsSuccess, Is.False);
    }
}
