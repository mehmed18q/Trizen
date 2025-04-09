using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Travel.Dto;

public record PassengerTravelDto
{
    [Display(Name = Resource.Tour)]
    public int TravelId { get; set; }
    public string? TravelPassengers { get; set; }
}