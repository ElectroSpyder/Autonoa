using AutoMapper;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.Model.ViewModel;

namespace Autonoa.Solucion.Model.Profile
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression AddAdminMapping(this IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<VehiculoModel, Vehiculo>()
                .ForMember(x => x.Modelo, o => o.MapFrom(p => p.Modelo))
                .ForMember(x => x.Marca, o => o.MapFrom(p => p.Marca))
                .ForMember(x => x.Motor, o => o.MapFrom(p => p.Motor))
                .ForMember(x => x.Precio, o => o.MapFrom(p => p.Precio))
                .ForMember(x => x.Color, o => o.MapFrom(p => p.Color))
                .ForMember(x => x.UrlImagen, o => o.MapFrom(p => p.UrlImagen));
            return configuration;
        }
    }
}
