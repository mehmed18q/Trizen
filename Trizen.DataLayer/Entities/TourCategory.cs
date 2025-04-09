using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class TourCategory
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Tour)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int TourId { get; set; }

    [Display(Name = Resource.Category)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }

    [ForeignKey(nameof(TourId))]
    public virtual Tour Tour { get; set; }
}