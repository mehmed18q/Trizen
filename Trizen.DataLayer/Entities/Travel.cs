using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.DataLayer.Entities;

public class Travel
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Tour)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int TraveledTourId { get; set; }

    [Display(Name = Resource.User)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int UserId { get; set; }

    [Display(Name = Resource.Status)]
    public TravelStatus Status { get; set; }

    [Display(Name = Resource.RegisterTime)]
    [Required(ErrorMessage = Message.RequiredError)]
    public DateTime RegisterTime { get; set; }

    [ForeignKey(nameof(TraveledTourId))]
    public virtual Tour Tour { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public virtual ICollection<Passenger> Passengers { get; set; } = [];
}
