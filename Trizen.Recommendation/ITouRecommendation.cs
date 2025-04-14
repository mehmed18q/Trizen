namespace Trizen.Recommendation;

public interface ITouRecommendation
{
    public Task<List<int>> GetRecommendedTours(int userId, int take);
}