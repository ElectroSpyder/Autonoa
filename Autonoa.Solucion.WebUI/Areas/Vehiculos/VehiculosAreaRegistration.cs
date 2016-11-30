using System.Web.Mvc;

namespace Autonoa.Solucion.WebUI.Areas.Vehiculos
{
    public class VehiculosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Vehiculos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Vehiculos_default",
                "Vehiculos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}