using System.Web.Mvc;

namespace EvaluacionesOnline.Areas.Seleccion
{
    public class SeleccionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Seleccion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            /*open>>> Sitio:  Evaluaciones */
            context.MapRoute(
                name: "V_EvaluacionesSitio",
                url: "Principal",
                defaults: new { controller = "EvaluacionesSitio", action = "V_EvaluacionesSitio" }
            );

            context.MapRoute(
                name: "AC_ActualizarDatosCandidato",
                url: "ActualizarDatosCandidato",
                defaults: new { controller = "EvaluacionesSitio", action = "AC_ActualizarDatosCandidato" }
            );

            context.MapRoute(
                name: "AC_ActualizarDatosCandidatoFicha",
                url: "ActualizarDatosCandidatoFicha",
                defaults: new { controller = "EvaluacionesSitio", action = "AC_ActualizarDatosCandidatoFicha" }
            );
            /*close>> Sitio */

                    /*open>>> Sitio:  Pruebas */
                    context.MapRoute(
                        name: "V_Pruebas",
                        url: "Pruebas",
                        defaults: new { controller = "Pruebas", action = "V_Pruebas" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Prueba parte*/
                    context.MapRoute(
                        name: "V_PruebaPartes",
                        url: "Pruebas/Partes",
                        defaults: new { controller = "Pruebas", action = "V_PruebaPartes" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Prueba parte preguntas */
                    context.MapRoute(
                        name: "V_PruebaPartePreguntas",
                        url: "Pruebas/Partes/Preguntas",
                        defaults: new { controller = "Pruebas", action = "V_PruebaPartePreguntas" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Prueba parte preguntas */
                    context.MapRoute(
                        name: "VP_Pregunta",
                        url: "Pruebas/Partes/Preguntas/Numero",
                        defaults: new { controller = "Pruebas", action = "VP_Pregunta" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  validacion */
                    context.MapRoute(
                        name: "AC_ValidarIngles",
                        url: "Pruebas/Partes/Preguntas/Validacion",
                        defaults: new { controller = "Pruebas", action = "AC_ValidarIngles" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Acción de respuesta */
                    context.MapRoute(
                        name: "AC_Respuesta",
                        url: "Pruebas/Partes/Preguntas/Respuesta",
                        defaults: new { controller = "Pruebas", action = "AC_Respuesta" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Acción de respuesta */
                    context.MapRoute(
                        name: "AC_NroPreguntas",
                        url: "Pruebas/Partes/Preguntas/BtnsPreguntas",
                        defaults: new { controller = "Pruebas", action = "AC_NroPreguntas" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Acción de respuesta */
                    context.MapRoute(
                        name: "AC_Terminar",
                        url: "Pruebas/Partes/Terminar",
                        defaults: new { controller = "Pruebas", action = "AC_Terminar" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Acción de respuesta */
                    context.MapRoute(
                        name: "AC_Tiempo",
                        url: "Pruebas/Partes/Tiempo",
                        defaults: new { controller = "Pruebas", action = "AC_Tiempo" }
                    );
                    /*close>> Sitio */

                    /*open>>> Sitio:  Acción de respuesta */
                    context.MapRoute(
                        name: "CF_LoadFile",
                        url: "Pruebas/Partes/LoadFile",
                        defaults: new { controller = "Pruebas", action = "CF_LoadFile" }
                    );
                    /*close>> Sitio */

            /*open>>> Sitio:  Acción de respuesta */
            context.MapRoute(
                name: "V_Informe",
                url: "Reportes/Informe",
                defaults: new { controller = "Reportes", action = "V_Informe" }
            );
            /*close>> Sitio */

            /*open>>> Sitio:  Acción de respuesta */
            context.MapRoute(
                name: "VP_Candidatos",
                url: "Reportes/Candidatos",
                defaults: new { controller = "Reportes", action = "VP_Candidatos" }
            );
            /*close>> Sitio */

            /*open>>> Sitio:  Acción de respuesta */
            context.MapRoute(
                name: "V_Reporte_Completo",
                url: "Reportes/InformeCompleto",
                defaults: new { controller = "Reportes", action = "V_Reporte_Completo" }
            );
            /*close>> Sitio */

            /*open>>> Sitio:  Acción de respuesta */
            context.MapRoute(
                name: "V_Reporte_Resumen",
                url: "Reportes/InformeResumen",
                defaults: new { controller = "Reportes", action = "V_Reporte_Resumen" }
            );
            /*close>> Sitio */

            /*open>>> Sitio:  Acción de respuesta */
            context.MapRoute(
                name: "V_Reporte_Grafico",
                url: "Reportes/InformeGrafico",
                defaults: new { controller = "Reportes", action = "V_Reporte_Grafico" }
            );
            /*close>> Sitio */

        }
    }
}
