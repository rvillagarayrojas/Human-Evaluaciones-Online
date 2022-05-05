using System.Web.Mvc;

namespace Sln23Core.Areas.Sistemas
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
            /*open>>> Sitio:  Sistemas */
                context.MapRoute(
                    name: "V_SistemasSitio",
                    url: "",
                    defaults: new { controller = "SistemasSitio", action = "V_SistemasSitio" }
                );

                context.MapRoute(
                    name: "V_GestionDeLaCalidad",
                    url: "Sistemas/GestionDeLaCalidad",
                    defaults: new { controller = "SistemasSitio", action = "V_GestionDeLaCalidad" }
                );
            /*close>> Sitio */

            /*open>>> Sitio:  Mensaje del Sistema */
                context.MapRoute(
                    name: "V_MensajeDelSistema",
                    url: "Sistemas/GestionDeLaCalidad/MensajeDelSistema",
                    defaults: new { controller = "GestionDeLaCalidad", action = "V_MensajeDelSistema" }
                );

                context.MapRoute(
                    name: "VP_MensajeDelSistema_Nuevo",
                    url: "Sistemas/GestionDeLaCalidad/MensajeDelSistema/Nuevo",
                    defaults: new { controller = "GestionDeLaCalidad", action = "VP_MensajeDelSistema_Nuevo" }
                );

                context.MapRoute(
                        name: "AC_MensajeDelSistema_Insertar",
                        url: "Sistemas/GestionDeLaCalidad/MensajeDelSistema/Insertar",
                        defaults: new { controller = "GestionDeLaCalidad", action = "AC_MensajeDelSistema_Insertar" }
                );
            /*close>> Sitio */
        }
    }
}
