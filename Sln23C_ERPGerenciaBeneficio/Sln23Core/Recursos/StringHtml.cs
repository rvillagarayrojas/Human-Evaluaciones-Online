using Entidad.A_Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sln23Core.Recursos
{
    public class StringHtml
    {
        public static String MsjTransaccion(E_Transaccion transaccion)
        {
            String Html23C      = "";
            string Class        = "success";
            string Estado       = "Petición atendida";
            string Icono        = "<i class=" + '"' + "glyphicon glyphicon-ok" + '"' + " ></i> ";
            string LlaveError   = "";

            if (transaccion.nu_tran_stdo == 0) 
            { 
                Class       = "danger"; 
                Estado      = "Petición en conflicto";
                Icono       = "<i class=" + '"' + "glyphicon glyphicon-remove" + '"' + " ></i> ";
                LlaveError  = "<label><strong>S</strong> <i class=" + '"' + "glyphicon glyphicon-chevron-right" + '"' + "></i> " + transaccion.nu_tran_pkey + "</label><br />";
            }
            else if (transaccion.nu_tran_stdo == 2)
            {
                Class       = "info";
                Estado      = "Los datos no pasaron la validación establecida";
                Icono       = "<i class=" + '"' + "glyphicon glyphicon-bishop" + '"' + " ></i> ";
            }
                
            Html23C = Html23C   + "<div class= " + '"' + " callout callout-"+ Class + '"' + ">" +
                                        "<label>" + Icono + " <strong> NOTIFICACIÓN</strong></label><br />" +
                                        transaccion.vc_tran_mnsg + "<br />" +
                                        "<label><i class=" + '"' + "glyphicon glyphicon-paperclip" + '"' + " ></i> <strong> Estándares</strong></label><br />" +
                                        "<label><strong>I</strong> <i class=" + '"' + "glyphicon glyphicon-chevron-right" + '"' + "></i> " + transaccion.nu_tran_idns   + "</label><br />" +
                                        "<label><strong>C</strong> <i class=" + '"' + "glyphicon glyphicon-chevron-right" + '"' + "></i> " + transaccion.vc_tran_codi   + "</label><br />" +
                                        "<label><strong>E</strong> <i class=" + '"' + "glyphicon glyphicon-chevron-right" + '"' + "></i> " + Estado                     + "</label><br />" +
                                        LlaveError +
                                  "</div>";


            return Html23C;
        }
    }
}