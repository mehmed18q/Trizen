using AutoMapper;
using Trizen.Data.Destination.ViewModel;
using Trizen.Data.Tour.Dto;
using Trizen.Data.Tour.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Extensions;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class TourMapperConfig : Profile, IRegisterMapper
    {
        public TourMapperConfig()
        {
            _ = CreateMap<CreateTourDto, Tour>()
                 .ForMember(destination => destination.StartTime, option => option.MapFrom(source => source.StartTime.ToMiladi()))
                  .ForMember(destination => destination.EndTime, option => option.MapFrom(source => source.EndTime.ToMiladi()));

            _ = CreateMap<TourViewModel, UpdateTourDto>();

            _ = CreateMap<UpdateTourDto, Tour>()
                               .ForMember(destination => destination.StartTime, option => option.MapFrom(source => source.StartTime.ToMiladi()))
                  .ForMember(destination => destination.EndTime, option => option.MapFrom(source => source.EndTime.ToMiladi()))
                .ForMember(destination => destination.Image, option => option.Ignore());

            _ = CreateMap<Tour, TourViewModel>()
              .ForMember(destination => destination.Image, option => option.MapFrom(source => $"/Images/Tour/{source.Image}"))
              .ForMember(destination => destination.Destination, option => option.MapFrom(source => source.Destination))
              .ForMember(destination => destination.Categories, option => option.MapFrom(source => source.TourCategories))
              .ForMember(destination => destination.TourTypeTitle, option => option.MapFrom(source => source.TourType.Title));


            _ = CreateMap<TourCategory, TourCategoryViewModel>()
              .ForMember(destination => destination.Id, option => option.MapFrom(source => source.CategoryId))
              .ForMember(destination => destination.Title, option => option.MapFrom(source => source.Category.Title));

            _ = CreateMap<Destination, DestinationViewModel>()
              .ForMember(destination => destination.Image, option => option.MapFrom(source => $"/Images/Destination/{source.Image}"))
              .ForMember(destination => destination.DestinationTypeTitle, option => option.MapFrom(source => source.DestinationType.Title));
        }
    }
}
