using Trizen.Infrastructure.Dapper;
using Trizen.Infrastructure.Interfaces;
using Trizen_Recommendation;

namespace Trizen.Recommendation;

public class TouRecommendation(IDapperService<object, object> dapperService) : ITouRecommendation, IRegisterServices
{
    private readonly IDapperService<object, object> _dapperService = dapperService;
    public async Task<List<int>> GetRecommendedTours(int userId, int take)
    {
        List<int> toursId;
        var parameter = new
        {
            userId
        };

        List<TourScore> tours = await _dapperService.Query<TourScore>("GetSuggestedTours", parameter);

        foreach (TourScore tour in tours)
        {
            RecommendationModel.ModelInput modelParameter = new()
            {
                UserId = userId,
                TourId = tour.TourId,
            };

            RecommendationModel.ModelOutput result = RecommendationModel.Predict(modelParameter);

            tour.Score = result.Score;
        }

        toursId = tours.OrderByDescending(tour => tour.Score).Take(take).Select(tour => tour.TourId).ToList();

        return toursId;
    }
}