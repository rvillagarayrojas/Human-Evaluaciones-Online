using EvaluacionesOnline.Areas.Seleccion.Controllers;
using EvaluacionesOnline.Areas.Seleccion.Models;
using MultiEntidad.A_Seleccion;
using Procedimiento.A_Seleccion;
using Procedimiento.A_Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using Entidad.A_General;
using EvaluacionesOnline.Areas.Sistemas.Models;

namespace EvaluacionesOnline.Areas.Sistemas.Controllers
{
    public class AccesoController : BaseController
    {
        private readonly P_Acceso _P_Acceso;
        private readonly P_Seguimiento _P_Seguimiento;


        public AccesoController()
        {
            this._P_Acceso = new P_Acceso();
            this._P_Seguimiento = new P_Seguimiento();
        }

        public ActionResult V_Acceso()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult AC_Acceder(PruebasModel model)
        {
            try
            {
                string status = _P_Acceso.Get_Acesso(model.mme_prueba);

                if (status.Length < 8)
                {
                    mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario    = decimal.Parse(status);
                    model.mme_prueba.me_prueba.candidato.nu_id_usuario          = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                    MME_Prueba PruebaCandidato                                  = _P_Acceso.Get_Datos(model.mme_prueba)[0];
                    mme_session.MME_Sesion.me_prueba.candidato.vc_nombres       = PruebaCandidato.me_prueba.candidato.vc_nombres;
                    mme_session.MME_Sesion.me_prueba.candidato.nu_id_perfil     = PruebaCandidato.me_prueba.candidato.nu_id_perfil;
                    mme_session.MME_Sesion.me_prueba.candidato.VC_IMAGEN_PERSONALIZAR = PruebaCandidato.me_prueba.candidato.VC_IMAGEN_PERSONALIZAR;
                    

                    //Inicio Registro de eventos de los candidatos (trazabilidad)
                    E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                    ObjEntSeguimiento.nu_id_usuario = model.mme_prueba.me_prueba.candidato.nu_id_usuario;
                    ObjEntSeguimiento.vc_nom_proceso = "LOGIN";
                    ObjEntSeguimiento.vc_nom_accion = "Iniciar Sesión";
                    ObjEntSeguimiento.vc_desc_accion = "Inicio Sesión con los datos: Usuario:" + model.mme_prueba.me_prueba.candidato.vc_cod_usuario + ", Pass:" + model.mme_prueba.me_prueba.candidato.vc_password;
                    ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                    ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                    _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                    //Inicio Registro de eventos de los candidatos (trazabilidad)
                }

                return Json(new { trans = status });
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult AC_Salir()
        {
            try
            {
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso = "LOGIN";
                ObjEntSeguimiento.vc_nom_accion = "Cerrar Sesión";
                ObjEntSeguimiento.vc_desc_accion = "Cerro Sesión el Usuario";
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                Session.RemoveAll();
                Session.Abandon();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult SalirTimer()
        {
            try
            {
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso = "LOGIN";
                ObjEntSeguimiento.vc_nom_accion = "Cerrar Sesión";
                ObjEntSeguimiento.vc_desc_accion = "Se Cerro la Sesión automaticamente por tiempo de espera";
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                Session[SesionModel.SessionName] = null;
                Session.RemoveAll();
                Session.Abandon();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult PageRestart(PruebasModel model)
        {
            return View();
        }

    }
}
