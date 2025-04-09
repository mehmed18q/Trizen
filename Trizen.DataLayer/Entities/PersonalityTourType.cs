using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class PersonalityTourType
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Personality)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int PersonalityId { get; set; }

    [ForeignKey(nameof(PersonalityId))]
    public virtual Personality Personality { get; set; }
    [Display(Name = Resource.TourType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int TourTypeId { get; set; }

    [ForeignKey(nameof(TourTypeId))]
    public virtual TourType TourType { get; set; }
}
