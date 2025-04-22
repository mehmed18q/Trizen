using Trizen.Data.Base.Dto;

namespace Trizen.Recommendation.Services;

public interface ITouRecommendation
{
    public Task<List<TourScoreDto>> GetRecommendedTours(int userId, int take);
}