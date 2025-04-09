using AutoMapper;
using Trizen.Data.User.Dto;
using Trizen.Data.User.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class UserMapperConfig : Profile, IRegisterMapper
    {
        public UserMapperConfig()
        {
            _ = CreateMap<User, ProfileViewModel>()
                .ForMember(destination => destination.ImageProfile, option => option.MapFrom(source => $"/Images/User/{source.ImageProfile}"));

            _ = CreateMap<User, UpdateProfileDto>()
                .ForMember(destination => destination.ImageProfile, option => option.MapFrom(source => $"/Images/User/{source.ImageProfile}"));

            _ = CreateMap<UpdateProfileDto, User>()
                .ForMember(destination => destination.ImageProfile, option => option.Ignore())
                .ForMember(destination => destination.BirthDay, option => option.MapFrom(source => source.BirthDay.ToMiladi()));

            _ = CreateMap<LikeTourDto, TourObserve>()
              .ForMember(destination => destination.ObserverUserId, option => option.MapFrom(source => source.UserId))
              .ForMember(destination => destination.ObservedTourId, option => option.MapFrom(source => source.TourId));
        }
    }
}
