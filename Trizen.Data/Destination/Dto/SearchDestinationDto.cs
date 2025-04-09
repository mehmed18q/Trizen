using Trizen.Infrastructure.Base;

namespace Trizen.Data.Destination.Dto;

public record SearchDestinationDto
{
    public Pagination Pagination { get; set; } = new();
}
