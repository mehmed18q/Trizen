using AutoMapper;
using Trizen.Data.Base.Dto;
using Trizen.Data.Base.ViewModel;
using Trizen.DataLayer.Entities;
using Trizen.Infrastructure.Interfaces;

namespace Trizen.Application.Mappers
{
    internal class BaseEntityMapperConfig : Profile, IRegisterMappers
    {
        public BaseEntityMapperConfig()
        {
            _ = CreateMap<CreateBaseEntityDto, Category>();
            _ = CreateMap<CreateBaseEntityDto, TourType>();
            _ = CreateMap<CreateBaseEntityDto, DestinationType>();

            _ = CreateMap<UpdateBaseEntityDto, Category>();
            _ = CreateMap<UpdateBaseEntityDto, TourType>();
            _ = CreateMap<UpdateBaseEntityDto, DestinationType>();

            _ = CreateMap<Category, BaseEntityViewModel>();
            _ = CreateMap<TourType, BaseEntityViewModel>();
            _ = CreateMap<DestinationType, BaseEntityViewModel>();

            _ = CreateMap<BaseEntityViewModel, UpdateBaseEntityDto>();
        }
    }
}
