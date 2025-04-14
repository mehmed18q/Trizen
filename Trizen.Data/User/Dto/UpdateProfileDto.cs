using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.User.Dto;

public record UpdateProfileDto
{
    public int Id { get; set; }
    [Display(Name = Resource.FirstName)]
    [MaxLength(200, ErrorMessage = Message.MaxLengthError)]
    public string? FirstName { get; set; }

    [Display(Name = Resource.LastName)]
    [MaxLength(300, ErrorMessage = Message.MaxLengthError)]
    public string? LastName { get; set; }

    public string? FullName => $"{FirstName} {LastName}";

    [Display(Name = Resource.BirthDay)]
    public DateTime? BirthDay { get; set; }

    [Display(Name = Resource.NationalCode)]
    [MaxLength(10, ErrorMessage = Message.MaxLengthError)]
    public string? NationalCode { get; set; }

    [Display(Name = Resource.Personality)]
    public int? PersonalityId { get; set; }

    [Display(Name = Resource.Gender)]
    public int? GenderId { get; set; }

    [Display(Name = Resource.Email)]
    [EmailAddress(ErrorMessage = Message.EmailAddressError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Email { get; set; }

    [Display(Name = Resource.ImageProfile)]
    public IFormFile? UploadImageProfile { get; set; }
    public string? ImageProfile { get; set; }
}