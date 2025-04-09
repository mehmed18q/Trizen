using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class User
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.UserName)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(50, ErrorMessage = Message.MaxLengthError)]
    public required string UserName { get; set; }

    [Display(Name = Resource.Password)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(200, ErrorMessage = Message.MaxLengthError)]
    public required string Password { get; set; }

    [Display(Name = Resource.FirstName)]
    [MaxLength(200, ErrorMessage = Message.MaxLengthError)]
    public string? FirstName { get; set; }

    [Display(Name = Resource.LastName)]
    [MaxLength(300, ErrorMessage = Message.MaxLengthError)]
    public string? LastName { get; set; }

    [Display(Name = Resource.BirthDay)]
    public DateTime? BirthDay { get; set; }

    [Display(Name = Resource.NationalCode)]
    [MaxLength(10, ErrorMessage = Message.MaxLengthError)]
    public string? NationalCode { get; set; }

    [Display(Name = Resource.Personality)]
    public int? PersonalityId { get; set; }

    [Display(Name = Resource.Role)]
    public int Role { get; set; }

    [Display(Name = Resource.PhoneNumber)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(11, ErrorMessage = Message.MaxLengthError)]
    public required string PhoneNumber { get; set; }

    [Display(Name = Resource.Email)]
    [EmailAddress(ErrorMessage = Message.EmailAddressError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? Email { get; set; }

    [Display(Name = Resource.WalletAmount)]
    public double WalletAmount { get; set; }

    [Display(Name = Resource.ImageProfile)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public string? ImageProfile { get; set; }

    [ForeignKey(nameof(PersonalityId))]
    public virtual Personality? Personality { get; set; }
    public virtual IEnumerable<TourObserve>? TourObserve { get; set; }
    public virtual IEnumerable<Passenger>? Passenger { get; set; }
}
