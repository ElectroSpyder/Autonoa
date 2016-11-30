using System.Web.Mvc;
using System.Web.Routing;
using Autonoa.Solucion.Model.Profile;

namespace Autonoa.Solucion.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //AutoMapperConfig.AddAdminMapping()
            var mappingConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddAdminMapping();
                cfg.CreateMissingTypeMaps = true;
            });
            mappingConfig.CreateMapper();
            //services.AddSingleton(x => mappingConfig.CreateMapper());
        }
    }
}
