using EvaluacionesOnline.Areas.Seleccion.Models;
using EvaluacionesOnline.Areas.Seleccion.Models.Validator;
using Procedimiento.A_Seleccion;
using Procedimiento.A_Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using Entidad.A_General;


namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    public class EvaluacionesSitioController : BaseModelController<PruebasModel>
    {
        private readonly P_Candidato_Evaluacion _P_Candidato_Evaluacion;
        private readonly P_Acceso               _P_Acceso;
        private readonly P_Seguimiento          _P_Seguimiento;

        public EvaluacionesSitioController() : base(new PruebasModelValidator())
        {
            this._P_Candidato_Evaluacion    = new P_Candidato_Evaluacion();
            this._P_Acceso                  = new P_Acceso();
            this._P_Seguimiento             = new P_Seguimiento();
        }

        public ActionResult V_EvaluacionesSitio()
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.candidato.nu_id_usuario  = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                model.mme_prueba.me_prueba.candidato_evaluacion     = _P_Candidato_Evaluacion.Sel(model.mme_prueba)[0].me_prueba.candidato_evaluacion;
                mme_session.MME_Sesion.me_prueba.candidato.vc_chatbot_key = model.mme_prueba.me_prueba.candidato_evaluacion.VC_CHATBOT_KEY;
                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult AC_ActualizarDatosCandidato(PruebasModel model)
        {
            try
            {
                model.mme_prueba.me_prueba.candidato.nu_id_usuario      = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                var status = _P_Candidato_Evaluacion.Upd_Candidato_Evaluacion(model.mme_prueba);

                model.mme_prueba.me_prueba.candidato.nu_id_usuario      = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                mme_session.MME_Sesion.me_prueba.candidato.vc_nombres   = _P_Acceso.Get_Datos(model.mme_prueba)[0].me_prueba.candidato.vc_nombres;

                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = model.mme_prueba.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso = "DATOS DEL CANDIDATO";
                ObjEntSeguimiento.vc_nom_accion =  "Registro de datos";
                ObjEntSeguimiento.vc_desc_accion = "Registró sus datos personales y acepto los terminos y condiciones ";
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return Json(new { trans = status });
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }
        }

        public ActionResult AC_ActualizarDatosCandidatoFicha(PruebasModel model)
        {
            try
            {
                model.mme_prueba.me_prueba.candidato.nu_id_usuario = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                var status = _P_Candidato_Evaluacion.Upd_Candidato_Evaluacion_ficha(model.mme_prueba);
            
                if (model.mme_prueba.me_prueba.ConocimientoDetalle.Count != 0)
                {
                    var status1 = _P_Candidato_Evaluacion.Ins(model.mme_prueba);
                }

                if (model.mme_prueba.me_prueba.EducacionDetalle.Count != 0)
                {
                    var status2 = _P_Candidato_Evaluacion.InsEducacion(model.mme_prueba);
                }
                if (model.mme_prueba.me_prueba.ExperienciaDetalle.Count != 0)
                {
                    var status3 = _P_Candidato_Evaluacion.InsExperienciaLaboral(model.mme_prueba);
                }
                if (model.mme_prueba.me_prueba.FamiliaresDetalle.Count != 0)
                {
                    var status4 = _P_Candidato_Evaluacion.InsFamiliares(model.mme_prueba);
                }

                model.mme_prueba.me_prueba.candidato.nu_id_usuario = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                mme_session.MME_Sesion.me_prueba.candidato.vc_nombres = _P_Acceso.Get_Datos(model.mme_prueba)[0].me_prueba.candidato.vc_nombres;

                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = model.mme_prueba.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso = "DATOS DEL CANDIDATO";
                ObjEntSeguimiento.vc_nom_accion = "Registro de datos";
                ObjEntSeguimiento.vc_desc_accion = "Registró su ficha de datos personales y acepto los terminos y condiciones "; 
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return Json(new { trans = status });
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }
    }
}
