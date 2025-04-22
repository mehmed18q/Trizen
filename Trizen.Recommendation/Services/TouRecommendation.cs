using Trizen.Data.Base.Dto;
using Trizen.Infrastructure.Dapper;
using Trizen.Infrastructure.Interfaces;
using Trizen_Recommendation;

namespace Trizen.Recommendation.Services;

public class TouRecommendation(IDapperService<object, object> dapperService) : ITouRecommendation, IRegisterServices
{
    private readonly IDapperService<object, object> _dapperService = dapperService;
    public async Task<List<TourScoreDto>> GetRecommendedTours(int userId, int take)
    {
        var parameter = new
        {
            userId
        };

        List<TourScoreDto> tours = await _dapperService.Query<TourScoreDto>("GetSuggestedTours", parameter);

        foreach (TourScoreDto tour in tours)
        {
            RecommendationModel.ModelInput modelParameter = new()
            {
                UserId = userId,
                TourId = tour.TourId,
            };

            RecommendationModel.ModelOutput result = RecommendationModel.Predict(modelParameter);

            tour.Score = result.Score;
        }

        return tours.OrderByDescending(tour => tour.Score).Take(take).ToList();
    }
}