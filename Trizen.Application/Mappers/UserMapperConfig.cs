using AutoMapper;
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class UserMapperConfig : Profile, IRegisterMappers
    {
        public UserMapperConfig()
        {
            _ = CreateMap<User, ProfileViewModel>()
                .ForMember(destination => destination.ImageProfile, option => option.MapFrom(source => $"/Images/User/{source.ImageProfile}"));

            _ = CreateMap<User, UpdateProfileDto>()
                .ForMember(destination => destination.ImageProfile, option => option.MapFrom(source => $"/Images/User/{source.ImageProfile}"))
                .ForMember(destination => destination.GenderId, option => option.MapFrom(source => source.Gender.ToInt()));

            _ = CreateMap<UpdateProfileDto, User>()
                .ForMember(destination => destination.ImageProfile, option => option.Ignore())
                .ForMember(destination => destination.BirthDay, option => option.MapFrom(source => source.BirthDay.ToGregorian()))
                .ForMember(destination => destination.Gender, option => option.MapFrom(source => source.GenderId.IsNotZeroOrNull() ? source.GenderId!.Value.ToEnum<UserGenders>() : UserGenders.Unset));

            _ = CreateMap<LikeTourDto, TourObserve>()
              .ForMember(destination => destination.ObserverUserId, option => option.MapFrom(source => source.UserId))
              .ForMember(destination => destination.ObservedTourId, option => option.MapFrom(source => source.TourId));


            _ = CreateMap<LikeDestinationDto, DestinationObserve>()
                .ForMember(destination => destination.ObserverUserId, option => option.MapFrom(source => source.UserId))
                .ForMember(destination => destination.ObservedDestinationId, option => option.MapFrom(source => source.DestinationId));

        }
    }
}
