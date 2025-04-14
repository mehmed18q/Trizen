using AutoMapper;
using Trizen.Data.Destination.Dto;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.Tour.ViewModel;
using Trizen.Data.User.Dto;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class DestinationMapperConfig : Profile, IRegisterMappers
    {
        public DestinationMapperConfig()
        {
            _ = CreateMap<CreateDestinationDto, Destination>();

            _ = CreateMap<DestinationViewModel, UpdateDestinationDto>();

            _ = CreateMap<UpdateDestinationDto, Destination>()
                .ForMember(destination => destination.Image, option => option.Ignore());


            _ = CreateMap<DestinationCategory, DestinationCategoryViewModel>()
              .ForMember(destination => destination.Id, option => option.MapFrom(source => source.CategoryId))
              .ForMember(destination => destination.Title, option => option.MapFrom(source => source.Category.Title));


            _ = CreateMap<Destination, DestinationViewModel>()
              .ForMember(destination => destination.Image, option => option.MapFrom(source => $"/Images/Destination/{source.Image}"))
              .ForMember(destination => destination.DestinationTypeTitle, option => option.MapFrom(source => source.DestinationType.Title))
              .ForMember(destination => destination.Categories, option => option.MapFrom(source => source.DestinationCategories));


            _ = CreateMap<LikeDestinationDto, DestinationObserve>()
                .ForMember(destination => destination.ObserverUserId, option => option.MapFrom(source => source.UserId))
              .ForMember(destination => destination.ObservedDestinationId, option => option.MapFrom(source => source.DestinationId));
        }
    }
}
