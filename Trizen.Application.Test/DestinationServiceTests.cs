using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System.Text;
using Trizen.Application.Services;
using Trizen.Data.Destination.Dto;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Test;

[TestFixture]
public class DestinationServiceTests
{
    private Mock<IDestinationRepository> _repositoryMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private Mock<IFileUtility> _fileUtilityMock = null!;
    private DestinationService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IDestinationRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();
        _fileUtilityMock = new Mock<IFileUtility>();

        _service = new DestinationService(
            _repositoryMock.Object,
            _unitOfWorkMock.Object,
            _mapperMock.Object,
            _fileUtilityMock.Object);
    }

    [Test]
    public async Task Create_WithUploadImage_UploadsAndDeletesOldImage_ReturnsSuccess()
    {
        CreateDestinationDto dto = new()
        {
            Title = "Test Destination",
            UploadImage = CreateFakeFormFile()
        };

        Destination destination = new() { Id = 123, Title = dto.Title, Image = "oldImage.jpg" };

        _ = _mapperMock.Setup(m => m.Map<Destination>(dto)).Returns(destination);

        // موک کردن آپلود فایل برای برگشت موفق
        _ = _fileUtilityMock
            .Setup(f => f.UploadFileLocal(It.IsAny<UploadFileDto>()))
            .ReturnsAsync(Response<string>.SuccessResult("newImage.jpg"));

        // موک کردن حذف فایل برای برگشت true
        _ = _fileUtilityMock
            .Setup(f => f.DeleteFileLocal(It.IsAny<DeleteFileDto>()))
            .Returns(true);

        _ = _repositoryMock.Setup(r => r.Insert(destination)).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.Create(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);

        // تایید اینکه آپلود و حذف فراخوانی شده
        _fileUtilityMock.Verify(f => f.UploadFileLocal(It.IsAny<UploadFileDto>()), Times.Once);
        _fileUtilityMock.Verify(f => f.DeleteFileLocal(It.IsAny<DeleteFileDto>()), Times.Once);
    }

    [Test]
    public async Task Create_WithoutUploadImage_ReturnsSuccess()
    {
        CreateDestinationDto dto = new()
        {
            Title = "Test Destination",
            UploadImage = null
        };

        Destination destination = new() { Id = 100, Title = dto.Title, Image = null };

        _ = _mapperMock.Setup(m => m.Map<Destination>(dto)).Returns(destination);
        _ = _repositoryMock.Setup(r => r.Insert(destination)).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.Create(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);

        _fileUtilityMock.Verify(f => f.UploadFileLocal(It.IsAny<UploadFileDto>()), Times.Never);
        _fileUtilityMock.Verify(f => f.DeleteFileLocal(It.IsAny<DeleteFileDto>()), Times.Never);
    }

    private IFormFile CreateFakeFormFile()
    {
        string content = "Fake file content";
        MemoryStream stream = new(Encoding.UTF8.GetBytes(content));
        return new FormFile(stream, 0, stream.Length, "Data", "test.jpg")
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg"
        };
    }
}

