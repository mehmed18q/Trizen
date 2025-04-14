
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.Infrastructure.Base.Response;

namespace Trizen.Application.Interfaces;

public interface IUserService
{
    Task<Response<ProfileViewModel>> Login(LoginUserDto dto);
    Task<Response<ProfileViewModel>> Register(RegisterUserDto dto);
    Task<Response<ProfileViewModel>> EditProfile(UpdateProfileDto dto);
    Task<Response<UpdateProfileDto>> GetProfile(int userId);
    Task<Response<string>> LikeTour(LikeTourDto dto);
    Task VisitTour(LikeTourDto dto);
    Task<(bool, bool, bool)> CheckProfileStatus(int userId);
    Task<(int, int, int, int)> GetSiteStatus();
    Task VisitDestination(LikeDestinationDto likeDestinationDto);
    Task<Response<string>> LikeDestination(LikeDestinationDto likeDestinationDto);
}
