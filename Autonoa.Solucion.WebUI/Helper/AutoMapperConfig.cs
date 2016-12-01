using AutoMapper;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.Model.ViewModel;

namespace Autonoa.Solucion.WebUI.Helper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VehiculoModel, Vehiculo>().ReverseMap();
            });
        }
    }
}