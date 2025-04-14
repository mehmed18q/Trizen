using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Enumerations;

namespace Trizen.DataLayer.Entities;

public class SuggestedTour
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [MaxLength(40)]
    public required string BatchId { get; set; }

    [Display(Name = Resource.User)]
    public int UserId { get; set; }

    [Display(Name = Resource.Gender)]
    public UserGenders Gender { get; set; }

    [Display(Name = Resource.Personality)]
    public int? PersonalityId { get; set; }

    [Display(Name = Resource.Age)]
    public int? UserAge { get; set; }

    [Display(Name = Resource.SuggestTime)]
    public DateTime SuggestTime { get; set; }

    [Display(Name = Resource.Tour)]
    public int TourId { get; set; }

    [Display(Name = Resource.Score)]
    public int Score { get; set; }

    [ForeignKey(nameof(TourId))]
    public virtual Tour Tour { get; set; } = null!;

    [ForeignKey(nameof(PersonalityId))]
    public virtual Personality? Personality { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
}