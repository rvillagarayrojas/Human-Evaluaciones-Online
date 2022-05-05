using System.Web.Mvc;

namespace EvaluacionesOnline.Areas.Sistemas
{
    public class SistemasAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sistemas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "V_Acceso",
                url: "",
                defaults: new { controller = "Acceso", action = "V_Acceso" }
            );

            context.MapRoute(
                name: "AC_Acceder",
                url: "Acceder",
                defaults: new { controller = "Acceso", action = "AC_Acceder" }
            );

            context.MapRoute(
                name: "AC_Salir",
                url: "Salir",
                defaults: new { controller = "Acceso", action = "AC_Salir" }
            );

            context.MapRoute(
                name: "SalirTimer",
                url: "Acceso/LogOut",
                defaults: new { controller = "Acceso", action = "SalirTimer" }
            );

            context.MapRoute(
                name: "PageRestart",
                url: "Acceso/PageRestart",
                defaults: new { controller = "Acceso", action = "PageRestart" }
            );

            
        }
    }
}
