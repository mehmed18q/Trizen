using AutoMapper;
using Moq;
using Trizen.Application.Services;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;

namespace Trizen.Application.Test;

[TestFixture]
public class ListServiceTests
{
    private Mock<IListRepository> _repositoryMock = null!;
    private Mock<IMapper> _mapperMock = null!;
    private ListService _service = null!;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IListRepository>();
        _mapperMock = new Mock<IMapper>();

        _service = new ListService(_repositoryMock.Object, _mapperMock.Object);
    }

    [Test]
    public async Task Categories_WithSelectedId_SetsIsSelectedTrue()
    {
        // Arrange
        int categoryId = 2;
        List<Category> categories =
        [
            new Category { Id = 1, Title = "Cat1" },
            new Category { Id = 2, Title = "Cat2" },
            new Category { Id = 3, Title = "Cat3" }
        ];
        _ = _repositoryMock.Setup(r => r.GetCategories()).ReturnsAsync(categories);

        List<ListViewModel> mappedCategories = [.. categories.Select(c => new ListViewModel { Id = c.Id, Title = c.Title })];
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(categories)).Returns(mappedCategories);

        // Act
        ListResponse<ListViewModel> response = await _service.Categories(categoryId);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Count, Is.EqualTo(3));
        Assert.That(response.Data.Single(c => c.Id == categoryId).IsSelected, Is.True);
        Assert.That(response.Data.Count(c => c.IsSelected), Is.EqualTo(1));
    }

    [Test]
    public async Task Destinations_WithNullSelectedId_SetsAllIsSelectedFalse()
    {
        // Arrange
        List<Destination> destinations =
        [
            new Destination { Id = 1, Title = "Dest1" },
            new Destination { Id = 2, Title = "Dest2" },
        ];
        _ = _repositoryMock.Setup(r => r.GetDestinations()).ReturnsAsync(destinations);

        List<ListViewModel> mappedDestinations = [.. destinations.Select(d => new ListViewModel { Id = d.Id, Title = d.Title })];
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(destinations)).Returns(mappedDestinations);

        // Act
        ListResponse<ListViewModel> response = await _service.Destinations(null);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.All(d => d.IsSelected == false));
    }

    [Test]
    public async Task DestinationTypes_SetsCorrectIsSelected()
    {
        // Arrange
        List<DestinationType> destinationTypes =
        [
            new DestinationType { Id = 5, Title = "Type5" },
            new DestinationType { Id = 6, Title = "Type6" }
        ];
        _ = _repositoryMock.Setup(r => r.GetDestinationTypes()).ReturnsAsync(destinationTypes);

        List<ListViewModel> mapped = destinationTypes.Select(d => new ListViewModel { Id = d.Id, Title = d.Title }).ToList();
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(destinationTypes)).Returns(mapped);

        // Act
        ListResponse<ListViewModel> response = await _service.DestinationTypes(6);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Single(d => d.Id == 6).IsSelected, Is.True);
        Assert.That(response.Data.Count(d => d.IsSelected), Is.EqualTo(1));
    }

    [Test]
    public async Task GetUsers_ReturnsMappedUsers()
    {
        // Arrange
        List<User> users =
        [
            new User { Id = 1, UserName = "User1", Password = "Password1", PhoneNumber="PhoneNumber1" },
            new User { Id = 2, UserName = "User2" , Password = "Password2", PhoneNumber="PhoneNumber2" }
        ];
        _ = _repositoryMock.Setup(r => r.GetUsers()).ReturnsAsync(users);

        List<ListViewModel> mappedUsers = users.Select(u => new ListViewModel { Id = u.Id, Title = u.UserName }).ToList();
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(users)).Returns(mappedUsers);

        // Act
        ListResponse<ListViewModel> response = await _service.GetUsers();

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Count, Is.EqualTo(2));
    }

    [Test]
    public async Task Personalities_SetsSelectedCorrectly()
    {
        // Arrange
        List<Personality> personalities =
        [
            new Personality { Id = 10, Title = "P1", Code = "C1" },
            new Personality { Id = 20, Title = "P2", Code = "C2" }
        ];
        _ = _repositoryMock.Setup(r => r.GetPersonalities()).ReturnsAsync(personalities);

        List<ListViewModel> mapped = personalities.Select(p => new ListViewModel { Id = p.Id, Title = p.Title }).ToList();
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(personalities)).Returns(mapped);

        // Act
        ListResponse<ListViewModel> response = await _service.Personalities(20);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Single(p => p.Id == 20).IsSelected, Is.True);
    }

    [Test]
    public async Task TourTypes_SetsSelectedCorrectly()
    {
        // Arrange
        List<TourType> tourTypes =
        [
            new TourType { Id = 100, Title = "T1" },
            new TourType { Id = 200, Title = "T2" }
        ];
        _ = _repositoryMock.Setup(r => r.GetTourTypes()).ReturnsAsync(tourTypes);

        List<ListViewModel> mapped = tourTypes.Select(t => new ListViewModel { Id = t.Id, Title = t.Title }).ToList();
        _ = _mapperMock.Setup(m => m.Map<List<ListViewModel>>(tourTypes)).Returns(mapped);

        // Act
        ListResponse<ListViewModel> response = await _service.TourTypes(100);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Single(t => t.Id == 100).IsSelected, Is.True);
    }

    [Test]
    public void UserGenders_WithSelectedId_SetsIsSelected()
    {
        // Arrange
        int selectedGenderId = UserGenders.Woman.ToInt();

        // Act
        ListResponse<ListViewModel> response = _service.UserGenders(selectedGenderId);

        // Assert
        Assert.That(response.IsSuccess, Is.True);
        Assert.That(response.Data.Any(g => g.Id == selectedGenderId && g.IsSelected));
    }
}
