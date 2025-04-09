using Trizen.Infrastructure.Base;

namespace Trizen.Data.Tour.Dto;

public record SearchTourDto
{
    public int UserId { get; set; }
    public Pagination Pagination { get; set; } = new();
}
