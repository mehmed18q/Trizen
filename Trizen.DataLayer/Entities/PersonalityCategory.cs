using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trizen.Infrastructure;

namespace Trizen.DataLayer.Entities;

public class PersonalityCategory
{
    [Key]
    [Display(Name = Resource.Id)]
    public int Id { get; set; }

    [Display(Name = Resource.Personality)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int PersonalityId { get; set; }

    [ForeignKey(nameof(PersonalityId))]
    public virtual Personality Personality { get; set; }

    [Display(Name = Resource.Category)]
    [Required(ErrorMessage = Message.RequiredError)]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; }
}
