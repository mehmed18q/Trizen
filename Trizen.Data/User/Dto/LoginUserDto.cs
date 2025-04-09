using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.User.Dto;

public record LoginUserDto
{
    [Display(Name = Resource.UserName)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(50, ErrorMessage = Message.MaxLengthError)]
    public required string UserName { get; set; }

    [Display(Name = Resource.Password)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(200, ErrorMessage = Message.MaxLengthError)]
    [MinLength(8, ErrorMessage = Message.MinLengthError)]
    [PasswordPropertyText(true)]
    public required string Password { get; set; }

    public string? ReturnUrl { get; set; }
}