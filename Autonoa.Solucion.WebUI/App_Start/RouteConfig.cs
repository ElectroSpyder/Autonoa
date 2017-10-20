using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Autonoa.Solucion.Data;
using Autonoa.Solucion.Model.ViewModel;

namespace Autonoa.Solucion.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vehiculo", action = "Index", id = UrlParameter.Optional }
            );

            //Mapper.Initialize(cfg => cfg.CreateMap<Vehiculo, VehiculoModel>());
            ////or
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Vehiculo, VehiculoModel>());
        }
    }
}
