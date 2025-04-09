
using Trizen.Data.Travel.Dto;
using Trizen.Data.Travel.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface ITravelService
{
    Task<ListResponse<BasketViewModel>> GetUserBasket(int userId);
    Task<Response<BasketViewModel>> Get(int travelId);
    Task<Response<BasketViewModel>> Create(CreateTravelDto dto);
    Task<Response<double>> TravelPassengerInsertUpdate(PassengerTravelDto dto);
    Task<Response<bool>> Pay(int travelId);
    Task<Response<bool>> Cancel(int travelId);
}
