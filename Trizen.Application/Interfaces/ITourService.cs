using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface ITourService
{
    Task<Response<bool>> Create(CreateTourDto dto);
    Task<Response<bool>> Update(UpdateTourDto dto);
    Task<Response<bool>> Delete(int id);
    Task<Response<TourViewModel>> Get(int id, int userId = 0);
    Task<ListResponse<TourViewModel>> GetAll(SearchTourDto dto);
    Task<Response<bool>> TourCategoryInsertUpdate(CategoryTourDto dto);
    Task<ListResponse<TourViewModel>> Search(SearchTourViewModel model);
    Task<ListResponse<TourViewModel>> GetFavoriteTours(int userId);
    Task<ListResponse<TourViewModel>> GetMyTours(int userId);
    Task<ListResponse<TourViewModel>> GetSuggestedTours(int userId);
}
