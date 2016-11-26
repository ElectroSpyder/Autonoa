using Autonoa.Solucion.Model.Profile;
using System.Web.Http;

namespace Autonoa.Solucion.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

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
