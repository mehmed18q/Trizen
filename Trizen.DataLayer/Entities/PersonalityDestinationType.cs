using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class PersonalityDestinationType
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Personality)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int PersonalityId { get; set; }

    [ForeignKey(nameof(PersonalityId))]
    public virtual Personality Personality { get; set; }
    [Display(Name = Resource.DestinationType)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int DestinationTypeId { get; set; }

    [ForeignKey(nameof(DestinationTypeId))]
    public virtual DestinationType DestinationType { get; set; }
}
