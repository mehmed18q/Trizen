using AutoMapper;
using Trizen.Data.Travel.Dto;
using Trizen.Data.Travel.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Enumerations;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class TravelMapperConfig : Profile, IRegisterMapper
    {
        public TravelMapperConfig()
        {
            _ = CreateMap<Travel, BasketViewModel>()
                .ForMember(destination => destination.User, option => option.MapFrom(source => source.User))
                .ForMember(destination => destination.Tour, option => option.MapFrom(source => source.Tour))
                .ForMember(destination => destination.PassengersList, option => option.MapFrom(source => source.Passengers));

            _ = CreateMap<Passenger, PassengerViewModel>()
                .ForMember(destination => destination.User, option => option.MapFrom(source => source.User));

            _ = CreateMap<CreateTravelDto, Travel>()
               .ForMember(destination => destination.RegisterTime, option => option.MapFrom(_ => DateTime.Now))
                .ForMember(destination => destination.TraveledTourId, option => option.MapFrom(source => source.TourId))
                .ForMember(destination => destination.Status, option => option.MapFrom(_ => TravelStatus.Processing));
        }
    }
}
