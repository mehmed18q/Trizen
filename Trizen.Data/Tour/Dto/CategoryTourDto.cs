using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Tour.Dto;

public record CategoryTourDto
{
    [Display(Name = Resource.Tour)]
    public int TourId { get; set; }
    public List<int>? TourCategoriesList { get; set; }
    public string? TourCategories { get; set; }
}

public record CategoryDestinationDto
{
    [Display(Name = Resource.Destination)]
    public int DestinationId { get; set; }
    public List<int>? DestinationCategoriesList { get; set; }
    public string? DestinationCategories { get; set; }
    
}


public record UpdatePersonalityDto
{
    [Display(Name = Resource.Personality)]
    public int PersonalityId { get; set; }
    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(50, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }

    [Display(Name = Resource.Code)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(4, ErrorMessage = Message.MaxLengthError)]
    public required string Code { get; set; }
    [Display(Name = Resource.Description)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Description { get; set; }
    public string? EntitieIds { get; set; }
    public string? Entity { get; set; }
}


public record PersonalityDto
{
    [Display(Name = Resource.Personality)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}
