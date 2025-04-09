using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.User.Dto;

public record RegisterUserDto : LoginUserDto
{
    [Display(Name = Resource.PhoneNumber)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(11, ErrorMessage = Message.MaxLengthError)]
    public required string PhoneNumber { get; set; }

    [Display(Name = Resource.RePassword)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(200, ErrorMessage = Message.MaxLengthError)]
    [MinLength(8, ErrorMessage = Message.MinLengthError)]
    [PasswordPropertyText(true)]
    [Compare(nameof(Password), ErrorMessage = Message.PasswordDoesNotMatch)]
    public required string RePassword { get; set; }

    [Display(Name = Resource.InviteCode)]
    public string? InviteCode { get; set; }
}