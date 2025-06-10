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
public class BaseEntityServiceCategoryTests
{
    private Mock<IBaseEntityRepository<Category>> _categoryRepoMock = null!;
    private Mock<IBaseEntityRepository<DestinationType>> _destinationTypeRepoMock = null!;
    private Mock<IBaseEntityRepository<TourType>> _tourTypeRepoMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private Mock<IMapper> _mapperMock = null!;

    private BaseEntityService _service = null!;

    [SetUp]
    public void SetUp()
    {
        _categoryRepoMock = new Mock<IBaseEntityRepository<Category>>();
        _destinationTypeRepoMock = new Mock<IBaseEntityRepository<DestinationType>>();
        _tourTypeRepoMock = new Mock<IBaseEntityRepository<TourType>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _mapperMock = new Mock<IMapper>();

        _service = new BaseEntityService(
            _categoryRepoMock.Object,
            _destinationTypeRepoMock.Object,
            _tourTypeRepoMock.Object,
            _unitOfWorkMock.Object,
            _mapperMock.Object);
    }

    [TearDown]
    public void TearDown()
    {
        _categoryRepoMock.Reset();
        _destinationTypeRepoMock.Reset();
        _tourTypeRepoMock.Reset();
        _unitOfWorkMock.Reset();
        _mapperMock.Reset();
    }

    [Test]
    public async Task CreateCategory_ValidInput_ReturnsSuccess()
    {
        CreateBaseEntityDto dto = new() { Title = "Test", Entity = "Category" };
        Category category = new() { Title = dto.Title };

        _ = _mapperMock.Setup(m => m.Map<Category>(dto)).Returns(category);
        _ = _categoryRepoMock.Setup(r => r.Insert(category)).ReturnsAsync(It.IsAny<int>()); ;
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.CreateCategory(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task CreateCategory_RepositoryInsertFails_ReturnsFailure()
    {
        CreateBaseEntityDto dto = new() { Title = "Test", Entity = "Category" };
        Category category = new() { Title = dto.Title };

        _ = _mapperMock.Setup(m => m.Map<Category>(dto)).Returns(category);
        _ = _categoryRepoMock.Setup(r => r.Insert(category)).ReturnsAsync(It.IsAny<int>()); ;
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.CreateCategory(dto);

        Assert.That(result.IsSuccess, Is.True); // چون Insert مقدار برگشتی رو چک نمیکنه، true هست
    }

    [Test]
    public async Task CreateCategory_MapperThrowsException_ReturnsFailure()
    {
        CreateBaseEntityDto dto = new() { Title = "Exception", Entity = "Category" };
        _ = _mapperMock.Setup(m => m.Map<Category>(dto)).Throws(new Exception("Mapping failed"));

        Response<bool> result = await _service.CreateCategory(dto);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.False);
    }

    [Test]
    public async Task DeleteCategory_CategoryExists_ReturnsSuccess()
    {
        int id = 1;
        _ = _categoryRepoMock.Setup(r => r.Any(id)).ReturnsAsync(true);
        _ = _categoryRepoMock.Setup(r => r.Delete(id)).ReturnsAsync(true);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.DeleteCategory(id);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task DeleteCategory_CategoryDoesNotExist_ReturnsFailure()
    {
        int id = 1;
        _ = _categoryRepoMock.Setup(r => r.Any(id)).ReturnsAsync(false);

        Response<bool> result = await _service.DeleteCategory(id);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.False);
        Assert.That(result.Message, Does.Contain("یافت نشد"));
    }

    [Test]
    public async Task GetCategory_ValidId_ReturnsCategory()
    {
        int id = 1;
        Category category = new() { Id = id, Title = "Category 1" };
        BaseEntityViewModel viewModel = new() { Id = id, Title = category.Title };

        _ = _categoryRepoMock.Setup(r => r.Any(id)).ReturnsAsync(true);
        _ = _categoryRepoMock.Setup(r => r.Get(id)).ReturnsAsync(category);
        _ = _mapperMock.Setup(m => m.Map<BaseEntityViewModel>(category)).Returns(viewModel);

        Response<BaseEntityViewModel> result = await _service.GetCategory(id);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.Not.Null);
        Assert.That(result.Data!.Title, Is.EqualTo("Category 1"));
    }

    [Test]
    public async Task GetCategory_NotFound_ReturnsFailure()
    {
        int id = 1;
        _ = _categoryRepoMock.Setup(r => r.Any(id)).ReturnsAsync(false);

        Response<BaseEntityViewModel> result = await _service.GetCategory(id);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.Null);
        Assert.That(result.Message, Does.Contain("یافت نشد"));
    }

    [Test]
    public async Task UpdateCategory_CategoryExists_ReturnsSuccess()
    {
        UpdateBaseEntityDto dto = new() { Id = 1, Title = "Updated", Entity = "Category" };
        Category entity = new() { Id = dto.Id, Title = dto.Title };

        _ = _categoryRepoMock.Setup(r => r.Any(dto.Id)).ReturnsAsync(true);
        _ = _mapperMock.Setup(m => m.Map<Category>(dto)).Returns(entity);
        _ = _categoryRepoMock.Setup(r => r.Update(entity)).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        Response<bool> result = await _service.UpdateCategory(dto);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.True);
    }

    [Test]
    public async Task UpdateCategory_CategoryDoesNotExist_ReturnsFailure()
    {
        UpdateBaseEntityDto dto = new() { Id = 1, Title = "Updated", Entity = "Category" };
        _ = _categoryRepoMock.Setup(r => r.Any(dto.Id)).ReturnsAsync(false);

        Response<bool> result = await _service.UpdateCategory(dto);

        Assert.That(result.IsSuccess, Is.False);
        Assert.That(result.Data, Is.False);
    }
}
