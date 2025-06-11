using Moq;
using Trizen.Application.Services;
using Trizen.Data.Tour.Dto;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Test;

[TestFixture]
public class PersonalityServiceTests
{
    private Mock<IPersonalityRepository> _repositoryMock = null!;
    private Mock<IUnitOfWork> _unitOfWorkMock = null!;
    private PersonalityService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IPersonalityRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();

        _service = new PersonalityService(_repositoryMock.Object, _unitOfWorkMock.Object);
    }

    [Test]
    public async Task GetAllCategories_ReturnsSuccessList()
    {
        List<int> list = [1, 2, 3];
        _ = _repositoryMock.Setup(r => r.GetAllCategories(It.IsAny<int>())).ReturnsAsync(list);

        ListResponse<int> result = await _service.GetAllCategories(5);

        Assert.That(result.IsSuccess, Is.True);
        Assert.That(result.Data, Is.EqualTo(list));
    }

    [Test]
    public async Task GetPersonality_ReturnsCorrectViewModel()
    {
        Personality personality = new()
        {
            Id = 1,
            Code = "P1",
            Title = "Title1",
            Description = "Desc1"
        };

        _ = _repositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(personality);

        Data.User.ViewModel.PersonalityViewModel result = await _service.GetPersonality(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(personality.Id));
        Assert.That(result.Code, Is.EqualTo(personality.Code));
    }

    [Test]
    public async Task PersonalityCategoryInsertUpdate_EntityExists_UpdatesAndSaves()
    {
        Personality personality = new()
        {
            Id = 1,
            Title = "OldTitle",
            Code = "OldCode",
            Description = "OldDesc",
            PersonalityCategories =
            [
                new PersonalityCategory { CategoryId = 1, PersonalityId = 1 },
                new PersonalityCategory { CategoryId = 2, PersonalityId = 1 }
            ]
        };

        _ = _repositoryMock.Setup(r => r.Any(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(personality);
        _ = _repositoryMock.Setup(r => r.AnyCategory(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Update(It.IsAny<Personality>())).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        UpdatePersonalityDto dto = new()
        {
            PersonalityId = 1,
            EntitieIds = "2,3",
            Title = "NewTitle",
            Code = "NewCode",
            Description = "NewDesc"
        };

        Response<bool> response = await _service.PersonalityCategoryInsertUpdate(dto);

        Assert.That(response.IsSuccess, Is.True);
        Assert.That(personality.Title, Is.EqualTo(dto.Title));
        Assert.That(personality.PersonalityCategories.Any(pc => pc.CategoryId == 3), Is.True);
        Assert.That(personality.PersonalityCategories.All(pc => dto.EntitieIds.Split(',').Select(int.Parse).Contains(pc.CategoryId)), Is.True);
        _repositoryMock.Verify(r => r.Update(personality), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task PersonalityCategoryInsertUpdate_EntityNotExists_ReturnsFail()
    {
        _ = _repositoryMock.Setup(r => r.Any(It.IsAny<int>())).ReturnsAsync(false);

        UpdatePersonalityDto dto = new() { PersonalityId = 99, Code = "C99", Title = "P99" };

        Response<bool> response = await _service.PersonalityCategoryInsertUpdate(dto);

        Assert.That(response.IsSuccess, Is.False);
    }


    [Test]
    public async Task PersonalityDestinationTypeInsertUpdate_EntityExists_UpdatesAndSaves()
    {
        Personality personality = new()
        {
            Id = 1,
            Code = "C1",
            Title = "P1",
            PersonalityDestinationTypes =
            [
                new PersonalityDestinationType { DestinationTypeId = 1, PersonalityId = 1 },
                new PersonalityDestinationType { DestinationTypeId = 2, PersonalityId = 1 }
            ]
        };

        _ = _repositoryMock.Setup(r => r.Any(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(personality);
        _ = _repositoryMock.Setup(r => r.AnyDestinationType(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Update(It.IsAny<Personality>())).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        UpdatePersonalityDto dto = new()
        {
            PersonalityId = 1,
            Code = "C1",
            Title = "P1",
            EntitieIds = "2,3"
        };

        Response<bool> response = await _service.PersonalityDestinationTypeInsertUpdate(dto);

        Assert.That(response.IsSuccess, Is.True);
        Assert.That(personality.PersonalityDestinationTypes.Any(pdt => pdt.DestinationTypeId == 3), Is.True);
        _repositoryMock.Verify(r => r.Update(personality), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }

    [Test]
    public async Task PersonalityTourTypeInsertUpdate_EntityExists_UpdatesAndSaves()
    {
        Personality personality = new()
        {
            Id = 1,
            Code = "C1",
            Title = "P1",
            PersonalityTourTypes =
            [
                new PersonalityTourType { TourTypeId = 1, PersonalityId = 1 },
                new PersonalityTourType { TourTypeId = 2, PersonalityId = 1 }
            ]
        };

        _ = _repositoryMock.Setup(r => r.Any(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(personality);
        _ = _repositoryMock.Setup(r => r.AnyTourType(It.IsAny<int>())).ReturnsAsync(true);
        _ = _repositoryMock.Setup(r => r.Update(It.IsAny<Personality>())).Returns(Task.CompletedTask);
        _ = _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);

        UpdatePersonalityDto dto = new()
        {
            PersonalityId = 1,
            Code = "C1",
            Title = "P1",
            EntitieIds = "2,3"
        };

        Response<bool> response = await _service.PersonalityTourTypeInsertUpdate(dto);

        Assert.That(response.IsSuccess, Is.True);
        Assert.That(personality.PersonalityTourTypes.Any(ptt => ptt.TourTypeId == 3), Is.True);
        _repositoryMock.Verify(r => r.Update(personality), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
    }
}
