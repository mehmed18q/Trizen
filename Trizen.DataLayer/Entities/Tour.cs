using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class Tour
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }

    [Display(Name = Resource.Description)]
    [MaxLength(5000, ErrorMessage = Message.MaxLengthError)]
    public string? Description { get; set; }

    [Display(Name = Resource.MinimumAge)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int MinimumAge { get; set; }

    [Display(Name = Resource.MaximumAge)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int MaximumAge { get; set; }

    [Display(Name = Resource.MaximumPassenger)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int MaximumPassenger { get; set; }

    [Display(Name = Resource.DaysCount)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DaysCount { get; set; }

    [Display(Name = Resource.SleepNightsCount)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int SleepNightsCount { get; set; }

    [Display(Name = Resource.Destination)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationId { get; set; }

    [Display(Name = Resource.TourType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int TourTypeId { get; set; }

    [Display(Name = Resource.StartTime)]
    [Required(ErrorMessage = Message.RequiredError)]
    public DateTime StartTime { get; set; }

    [Display(Name = Resource.EndTime)]
    [Required(ErrorMessage = Message.RequiredError)]
    public DateTime EndTime { get; set; }

    [Display(Name = Resource.Price)]
    public double Price { get; set; }

    [Display(Name = Resource.Image)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Image { get; set; }

    [ForeignKey(nameof(TourTypeId))]
    public virtual TourType TourType { get; set; } = null!;

    [ForeignKey(nameof(DestinationId))]
    public virtual Destination Destination { get; set; } = null!;

    public virtual ICollection<TourCategory> TourCategories { get; set; } = [];
    public virtual ICollection<TourObserve> TourObserves { get; set; } = [];
    public virtual ICollection<Travel> Travels { get; set; } = [];
}