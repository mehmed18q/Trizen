using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class DestinationCategory
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Destination)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationId { get; set; }

    [Display(Name = Resource.Category)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }

    [ForeignKey(nameof(DestinationId))]
    public virtual Destination Destination { get; set; }
}