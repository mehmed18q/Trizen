using Microsoft.EntityFrameworkCore;
using Trizen.DataLayer.Entities;

namespace Trizen.DataLayer;
public class TrizenDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Destination> Destinations => Set<Destination>();
    public DbSet<DestinationCategory> DestinationCategories => Set<DestinationCategory>();
    public DbSet<DestinationType> DestinationTypes => Set<DestinationType>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Personality> Personalities => Set<Personality>();
    public DbSet<PersonalityCategory> PersonalityCategories => Set<PersonalityCategory>();
    public DbSet<PersonalityDestinationType> PersonalityDestinationTypes => Set<PersonalityDestinationType>();
    public DbSet<PersonalityTourType> PersonalityTourTypes => Set<PersonalityTourType>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<TourCategory> TourCategories => Set<TourCategory>();
    public DbSet<TourObserve> TourObserves => Set<TourObserve>();
    public DbSet<TourType> TourTypes => Set<TourType>();
    public DbSet<Travel> Travels => Set<Travel>();
    public DbSet<User> Users => Set<User>();
}
