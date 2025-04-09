using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Base.Dto;

public record CreateBaseEntityDto
{
    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }

    public required string Entity { get; set; }
}
