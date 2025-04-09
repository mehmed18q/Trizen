using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Base.ViewModel;

public record BaseEntityViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }
}