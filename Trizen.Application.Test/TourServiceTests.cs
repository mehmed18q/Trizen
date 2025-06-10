using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Trizen.Application.Services;
using Trizen.Data.Tour.Dto;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Test;

[TestFixture]
public class TourService_Create_Tests
{
    private Mock<ITourRepository> _tourRepositoryMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private Mock<IUserRepository> _userRepositoryMock = null!;
    private Mock<IFileUtility> _fileUtilityMock = null!;
    private TourService _service = null!;

    [SetUp]
    public void Setup()
    {
        _tourRepositoryMock = new Mock<ITourRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _userRepositoryMock = new Mock<IUserRepository>();
        _fileUtilityMock = new Mock<IFileUtility>();

        _service = new TourService(
            _tourRepositoryMock.Object,
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _userRepositoryMock.Object,
            _fileUtilityMock.Object
        );
    }

    [Test]
    public async Task Create_ShouldReturnSuccess_WhenValidDataWithoutImage()
    {
        // Arrange
        CreateTourDto dto = new()
        {
            Title = "Tour 1",
            MinimumAge = 18,
            MaximumAge = 50,
            MaximumPassenger = 30,
            DaysCount = 3,
            SleepNightsCount = 2,
            DestinationId = 1,
            TourTypeId = 1,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(3)
        };
        Tour mappedTour = new() { Id = 1, Title = "Test Title" };

        _ = _mapperMock.Setup(m => m.Map<Tour>(dto)).Returns(mappedTour);
        _ = _tourRepositoryMock.Setup(r => r.Insert(It.IsAny<Tour>())).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        // Act
        Response<bool> result = await _service.Create(dto);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task Create_ShouldReturnSuccess_WithImageUpload()
    {
        // Arrange
        Mock<IFormFile> formFileMock = new();
        _ = formFileMock.Setup(f => f.FileName).Returns("test.jpg");

        CreateTourDto dto = new()
        {
            Title = "Tour 2",
            MinimumAge = 18,
            MaximumAge = 50,
            MaximumPassenger = 30,
            DaysCount = 3,
            SleepNightsCount = 2,
            DestinationId = 1,
            TourTypeId = 1,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddDays(3),
            UploadImage = formFileMock.Object
        };

        Tour mappedTour = new() { Id = 1, Title = "Test Title", Image = "old.jpg" };

        _ = _mapperMock.Setup(m => m.Map<Tour>(dto)).Returns(mappedTour);
        _ = _fileUtilityMock.Setup(f => f.UploadFileLocal(It.IsAny<UploadFileDto>()))
            .ReturnsAsync(Response<string>.SuccessResult("new.jpg"));
        _ = _fileUtilityMock.Setup(f => f.DeleteFileLocal(It.IsAny<DeleteFileDto>()));
        _ = _tourRepositoryMock.Setup(r => r.Insert(It.IsAny<Tour>())).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        // Act
        Response<bool> result = await _service.Create(dto);

        // Assert
        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public void Create_ShouldThrowException_WhenMapperFails()
    {
        // Arrange
        CreateTourDto dto = new() { Title = "Tour 3" };
        _ = _mapperMock.Setup(m => m.Map<Tour>(dto)).Throws(new Exception("Mapping failed"));

        // Act & Assert
        Exception? ex = Assert.ThrowsAsync<Exception>(() => _service.Create(dto));
        Assert.That(ex!.Message, Is.EqualTo("Mapping failed"));
    }
}
