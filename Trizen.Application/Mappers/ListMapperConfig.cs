using AutoMapper;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class ListMapperConfig : Profile, IRegisterMapper
    {
        public ListMapperConfig()
        {
            _ = CreateMap<Personality, ListViewModel>()
                .ForMember(destination => destination.Title, option => option.MapFrom(source => $"{source.Title} ({source.Code})"));

            _ = CreateMap<Destination, ListViewModel>();

            _ = CreateMap<TourType, ListViewModel>();

            _ = CreateMap<Category, ListViewModel>();

            _ = CreateMap<DestinationType, ListViewModel>();

            _ = CreateMap<User, ListViewModel>()
                .ForMember(destination => destination.Title, option => option.MapFrom(source => $"{source.FirstName} {source.LastName} ({source.UserName})"));
        }
    }
}
