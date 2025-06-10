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
public class BaseEntityServiceDestinationTypeTests
{
    private Mock<IBaseEntityRepository<DestinationType>> _destinationTypeRepoMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private BaseEntityService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _destinationTypeRepoMock = new Mock<IBaseEntityRepository<DestinationType>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _service = new BaseEntityService(
            categoryRepository: null!,
            destinationTypeRepository: _destinationTypeRepoMock.Object,
            tourTypeRepository: null!,
            unitOfWork: _unitOfWorkMock.Object,
            mapper: _mapperMock.Object);
    }

    [Test]
    public async Task CreateDestinationType_ValidInput_ReturnsSuccess()
    {
        CreateBaseEntityDto dto = new() { Title = "Beach", Entity = "DestinationType" };
        DestinationType entity = new() { Title = dto.Title };

        _ = _mapperMock.Setup(m => m.Map<DestinationType>(dto)).Returns(entity);
        _ = _destinationTypeRepoMock.Setup(r => r.Insert(entity)).ReturnsAsync(1);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.CreateDestinationType(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task GetDestinationType_NotFound_ReturnsFailure()
    {
        int id = 999;
        _ = _destinationTypeRepoMock.Setup(r => r.Any(id)).ReturnsAsync(false);

        Response<BaseEntityViewModel> result = await _service.GetDestinationType(id);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.Null);
    }

    [Test]
    public async Task UpdateDestinationType_Exists_ReturnsSuccess()
    {
        UpdateBaseEntityDto dto = new() { Id = 2, Title = "Updated", Entity = "DestinationType" };
        DestinationType entity = new() { Id = dto.Id, Title = dto.Title };

        _ = _destinationTypeRepoMock.Setup(r => r.Any(dto.Id)).ReturnsAsync(true);
        _ = _mapperMock.Setup(m => m.Map<DestinationType>(dto)).Returns(entity);
        _ = _destinationTypeRepoMock.Setup(r => r.Update(entity)).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.UpdateDestinationType(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task DeleteDestinationType_NotFound_ReturnsFailure()
    {
        int id = 10;
        _ = _destinationTypeRepoMock.Setup(r => r.Any(id)).ReturnsAsync(false);

        Response<bool> result = await _service.DeleteDestinationType(id);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.False);
    }
}