using Entidad.A_Sistemas;
using MacroEntidad.A_Sistemas;
using MultiEntidad.Sln23C;
using Procedimiento.A_Sistemas;
using Sln23Core.Areas.Sistemas.Models;
using Sln23Core.Recursos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sln23Core.Areas.Sistemas.Controllers
{
    public class GestionDeLaCalidadController : Controller
    {
        private readonly P_Mensaje_Sistema _P_Mensaje_Sistema;

        public GestionDeLaCalidadController()
        {
            _P_Mensaje_Sistema = new P_Mensaje_Sistema();
        }

        /*open>>> Región: Definimos la región para gestionar las acciones del módulo de Gestión de la Calidad */
        #region Gestión de la Calidad

            public ActionResult V_MensajeDelSistema()
            {
                return View();
            }


            /*open>>> Sub-región: Definimos la sub región para gestionar las acciones de mensaje del sistema */
            #region Mensaje del Sistema

                /*open-close>>> Acción: Consulta de registros de mensaje del sistema */
                public ActionResult VP_MensajeDelSistema_Consultar()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */

                    var modelo = new GestionDeLaCalidadModel();
                    return PartialView("VP_MensajeDelSistema_Consultar", modelo);
                }

                /*open-close>>> Acción: Visualizar el detalle de un registro */
                public ActionResult VP_MensajeDelSistema_Ver()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */

                    var modelo = new GestionDeLaCalidadModel();
                    return PartialView("VP_MensajeDelSistema_Consultar", modelo);
                }

                /*open-close>>> Acción: Solicitar vista para insertar nuevo registro */
                public ActionResult VP_MensajeDelSistema_Nuevo()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */

                    var modelo = new GestionDeLaCalidadModel();
                    return PartialView("VP_MensajeDelSistema_Nuevo", modelo);
                }

                /*open-close>>> Acción: Insertar nuevo registro */
                public ActionResult AC_MensajeDelSistema_Insertar(GestionDeLaCalidadModel modelo)
                {
                    /*open-close>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;

                        modelo.mme.me_mensaje_sistema.transaccion = new E_Transaccion();
                        modelo.mme.me_mensaje_sistema.transaccion.vc_tran_usua_regi = "Sln23C";
                        modelo.mme.me_mensaje_sistema.transaccion.nu_tran_ruta      = 1;
                        modelo.mme = _P_Mensaje_Sistema.Ins(modelo.mme);
                        return Json(new { trans = StringHtml.MsjTransaccion(modelo.mme.me_mensaje_sistema.transaccion) });
                }   

                /*open-close>>> Acción: Solicitar vista para editar un registro existente */
                public ActionResult VP_MensajeDelSistema_Editar()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */
                    var modelo = new GestionDeLaCalidadModel();
                    return PartialView("VP_MensajeDelSistema_Nuevo", modelo);
                }

                /*open-close>>> Acción: Actualizar los datos de un registro */
                public ActionResult AC_MensajeDelSistema_Actualizar()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */
                    return null;
                }

                /*open-close>>> Acción: Actualizar el o los estado(s) de un registro */
                public ActionResult AC_MensajeDelSistema_Estado()
                {
                    /*open>>> Identificación: Definimos idns para la acción */
                        Decimal Idns = 201000100001001;
                    /*close>> Identificación */
                    return null;
                }

            #endregion
            /*close>> Sub-región */


        #endregion
        /*close>> Región */

    }
}
