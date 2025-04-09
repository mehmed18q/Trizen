using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.User.ViewModel;

public record PersonalityViewModel
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

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
}
