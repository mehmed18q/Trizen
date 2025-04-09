using System.ComponentModel.DataAnnotations;
using Trizen.Infrastructure;

namespace Trizen.Data.Base.Dto;

public record UpdateBaseEntityDto : CreateBaseEntityDto
{
    [Display(Name = Resource.Id)]
    public int Id { get; set; }
}
