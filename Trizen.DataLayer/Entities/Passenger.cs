using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class Passenger
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Travel)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int TravelId { get; set; }

    [Display(Name = Resource.User)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int PassengerUserId { get; set; }

    [ForeignKey(nameof(PassengerUserId))]
    public virtual User User { get; set; }
}