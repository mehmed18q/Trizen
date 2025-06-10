using AutoMapper;
using Moq;
using Trizen.Application.Services;
using Trizen.Data.Base.Dto;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Test;

[TestFixture]
public class BaseEntityServiceTourTypeTests
{
    private Mock<IBaseEntityRepository<TourType>> _tourTypeRepoMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private BaseEntityService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _tourTypeRepoMock = new Mock<IBaseEntityRepository<TourType>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _service = new BaseEntityService(
            categoryRepository: null!,
            destinationTypeRepository: null!,
            tourTypeRepository: _tourTypeRepoMock.Object,
            unitOfWork: _unitOfWorkMock.Object,
            mapper: _mapperMock.Object);
    }

    [Test]
    public async Task CreateTourType_ValidInput_ReturnsSuccess()
    {
        CreateBaseEntityDto dto = new() { Title = "Adventure", Entity = "TourType" };
        TourType entity = new() { Title = dto.Title };

        _ = _mapperMock.Setup(m => m.Map<TourType>(dto)).Returns(entity);
        _ = _tourTypeRepoMock.Setup(r => r.Insert(entity)).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.CreateTourType(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task GetTourType_NotFound_ReturnsFailure()
    {
        int id = 5;
        _ = _tourTypeRepoMock.Setup(r => r.Any(id)).ReturnsAsync(false);

        Response<BaseEntityViewModel> result = await _service.GetTourType(id);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.Null);
    }

    [Test]
    public async Task UpdateTourType_Exists_ReturnsSuccess()
    {
        UpdateBaseEntityDto dto = new() { Id = 3, Title = "Luxury", Entity = "TourType" };
        TourType entity = new() { Id = dto.Id, Title = dto.Title };

        _ = _tourTypeRepoMock.Setup(r => r.Any(dto.Id)).ReturnsAsync(true);
        _ = _mapperMock.Setup(m => m.Map<TourType>(dto)).Returns(entity);
        _ = _tourTypeRepoMock.Setup(r => r.Update(entity)).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.UpdateTourType(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task DeleteTourType_ValidId_ReturnsSuccess()
    {
        int id = 4;
        _ = _tourTypeRepoMock.Setup(r => r.Any(id)).ReturnsAsync(true);
        _ = _tourTypeRepoMock.Setup(r => r.Delete(id)).ReturnsAsync(true);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.DeleteTourType(id);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }
}
