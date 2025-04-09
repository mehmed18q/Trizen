using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.DataLayer.Entities;

public class TourObserve
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Tour)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int ObservedTourId { get; set; }

    [Display(Name = Resource.User)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int ObserverUserId { get; set; }

    public ObserveType ObserveType { get; set; }

    [ForeignKey(nameof(ObserverUserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(ObservedTourId))]
    public virtual Tour Tour { get; set; }
}
