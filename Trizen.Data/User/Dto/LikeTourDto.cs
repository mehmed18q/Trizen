using Trizen.Infrastructure.Enumerations;

namespace Trizen.Data.User.Dto;

public record LikeTourDto
{
    public int TourId { get; set; }
    public int UserId { get; set; }
    public bool IsLiked { get; set; }
    public ObserveType ObserveType { get; set; }
}

public record LikeDestinationDto
{
    public int DestinationId { get; set; }
    public int UserId { get; set; }
    public bool IsLiked { get; set; }
    public ObserveType ObserveType { get; set; }
}