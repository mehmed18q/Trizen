using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class BaseEntity
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Title)]
    [Required(ErrorMessage = Message.RequiredError)]
    [MaxLength(500, ErrorMessage = Message.MaxLengthError)]
    public required string Title { get; set; }
}