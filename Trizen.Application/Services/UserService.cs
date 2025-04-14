using AutoMapper;
using Microsoft.Extensions.Options;
using Trizen.Application.Interfaces;
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.DataLayer.Interfaces;
using Trizen.DataLayer.Pattern;
using Trizen.Infrastructure;
using Trizen.Infrastructure.Base;
using Trizen.Infrastructure.Base.File;
using Trizen.Infrastructure.Base.Response;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;
using Trizen.Infrastructure.Utilities;

namespace Trizen.Application.Services;

internal class UserService(IUserRepository repository, IUnitOfWork unitOfWork, IMapper mapper, IOptions<TrizenConfiguration> configuration, ITourRepository tourRepository, IDestinationRepository destinationRepository) : IUserService, IRegisterServices
{
    private readonly IUserRepository _repository = repository;
    private readonly ITourRepository _tourRepository = tourRepository;
    private readonly IDestinationRepository _destinationRepository = destinationRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly TrizenConfiguration _configuration = configuration.Value;

    public async Task<Response<ProfileViewModel>> EditProfile(UpdateProfileDto dto)
    {
        User? user = await _repository.GetUserById(dto.Id);
        if (user is not null)
        {
            user = _mapper.Map(dto, user);
            if (dto.UploadImageProfile is not null)
            {
                Response<string> newImage = await FileUtility.UploadFileLocal(new UploadFileDto
                {
                    Entity = nameof(User),
                    File = dto.UploadImageProfile,
                });

                if (newImage.IsSuccess && user.ImageProfile.IsNotEmpty())
                {
                    _ = FileUtility.DeleteFileLocal(new DeleteFileDto
                    {
                        Entity = nameof(User),
                        FileName = user.ImageProfile!
                    });
                }

                if (newImage.IsSuccess)
                {
                    user.ImageProfile = newImage.Data;
                }
            }

            await _repository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            ProfileViewModel userInformation = _mapper.Map<ProfileViewModel>(user);

            return Response<ProfileViewModel>.SuccessResult(userInformation, Message.EditProfileSuccess);
        }

        return Response<ProfileViewModel>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.User));
    }

    public async Task<Response<UpdateProfileDto>> GetProfile(int userId)
    {
        User? _user = await _repository.GetUserById(userId);
        if (_user is not null)
        {
            UpdateProfileDto userInformation = _mapper.Map<UpdateProfileDto>(_user);
            return Response<UpdateProfileDto>.SuccessResult(userInformation);
        }

        return Response<UpdateProfileDto>.FailResult(null, Message.Format(Message.EntityNotFound, Resource.User));
    }

    public async Task<Response<string>> LikeTour(LikeTourDto dto)
    {
        if (await _tourRepository.Any(dto.TourId))
        {
            TourObserve model = _mapper.Map<TourObserve>(dto);

            if (await _repository.AnyLikeTour(dto.UserId, dto.TourId))
            {
                TourObserve? observe = await _repository.GetTourObserve(model);
                if (observe is not null)
                {
                    observe.ObserveType = ObserveType.Visit;
                    await _repository.UpdateTourObserve(observe);
                    await _unitOfWork.SaveChangesAsync();

                    return Response<string>.SuccessResult(Message.Success);
                }
            }
            else
            {
                await _repository.ObserveTour(model);
                await _unitOfWork.SaveChangesAsync();
                return Response<string>.SuccessResult(Message.LikeTourSuccess);
            }
        }
        return Response<string>.FailResult(Message.Format(Message.EntityNotFound, Resource.Tour));
    }

    public async Task<Response<string>> LikeDestination(LikeDestinationDto dto)
    {
        if (await _destinationRepository.Any(dto.DestinationId))
        {
            DestinationObserve model = _mapper.Map<DestinationObserve>(dto);

            if (await _repository.AnyLikeDestination(dto.UserId, dto.DestinationId))
            {
                DestinationObserve? observe = await _repository.GetDestinationObserve(model);
                if (observe is not null)
                {
                    observe.ObserveType = ObserveType.Visit;
                    await _repository.UpdateDestinationObserve(observe);
                    await _unitOfWork.SaveChangesAsync();

                    return Response<string>.SuccessResult(Message.Success);
                }
            }
            else
            {
                await _repository.ObserveDestination(model);
                await _unitOfWork.SaveChangesAsync();
                return Response<string>.SuccessResult(Message.LikeTourSuccess);
            }
        }
        return Response<string>.FailResult(Message.Format(Message.EntityNotFound, Resource.Destination));
    }

    public async Task VisitTour(LikeTourDto dto)
    {
        if (await _tourRepository.Any(dto.TourId))
        {
            TourObserve model = _mapper.Map<TourObserve>(dto);
            await _repository.ObserveTour(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<Response<ProfileViewModel>> Login(LoginUserDto dto)
    {
        string hashedPassword = dto.Password.HashPassword();
        User? user = await _repository.GetUser(dto.UserName, hashedPassword);
        ProfileViewModel userInformation = new()
        {
            UserName = dto.UserName,
        };

        if (user is not null)
        {
            userInformation = _mapper.Map<ProfileViewModel>(user);
            return Response<ProfileViewModel>.SuccessResult(userInformation);
        }

        return Response<ProfileViewModel>.FailResult(userInformation, Message.Format(Message.EntityNotFound, Resource.User));
    }

    public async Task<Response<ProfileViewModel>> Register(RegisterUserDto dto)
    {
        if (await _repository.AnyUser(dto.UserName, dto.PhoneNumber))
        {
            return Response<ProfileViewModel>.FailResult(null, Message.UserNameOrPhoneNumberIsDuplicate);
        }

        User user = new()
        {
            UserName = dto.UserName,
            Password = dto.Password.HashPassword(),
            PhoneNumber = dto.PhoneNumber,
            WalletAmount = _configuration.EntryGiftAmount,
            Role = dto.InviteCode.IsNotEmpty() && dto.InviteCode == _configuration.InviteCode ? UserRoles.Admin : _configuration.DefaultUserRole,
            Gender = UserGenders.Unset,
            ImageProfile = Resource.DefaultImage
        };

        await _repository.Insert(user);
        await _unitOfWork.SaveChangesAsync();
        ProfileViewModel userInformation = _mapper.Map<ProfileViewModel>(user);

        return Response<ProfileViewModel>.SuccessResult(userInformation);
    }

    public async Task<(bool, bool, bool)> CheckProfileStatus(int userId)
    {
        User? user = await _repository.GetUserById(userId);
        if (user is null)
        {
            return (false, false, false);
        }
        else
        {
            bool haveTravel = await _tourRepository.CheckHaveTravel(userId);
            bool importantInformation = user.BirthDay.HasValue && user.PersonalityId.HasValue && user.FirstName.IsNotEmpty() && user.LastName.IsNotEmpty();
            return (importantInformation,
                importantInformation && user.NationalCode.IsNotEmpty() && user.Email.IsNotEmpty() && user.ImageProfile != "DefaultImage.jpg",
                haveTravel);
        }
    }

    public async Task<(int, int, int, int)> GetSiteStatus()
    {
        return (await _repository.UserCounts(),
            await _repository.ToursCounts(),
            await _repository.DestinationsCounts(),
            await _repository.TravelsCounts());
    }

    public async Task VisitDestination(LikeDestinationDto dto)
    {
        if (await _destinationRepository.Any(dto.DestinationId))
        {
            DestinationObserve model = _mapper.Map<DestinationObserve>(dto);
            await _repository.ObserveDestination(model);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
