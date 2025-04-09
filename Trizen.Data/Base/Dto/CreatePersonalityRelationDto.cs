using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Base.Dto;

public record CreatePersonalityRelationDto
{
    [Display(Name = Resource.Id)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int BaseId { get; set; }

    [Required(ErrorMessage = Message.RequiredError)]
    [Display(Name = Resource.Personality)]
    public required int PersonalityId { get; set; }

    public required string Entity { get; set; }
}
