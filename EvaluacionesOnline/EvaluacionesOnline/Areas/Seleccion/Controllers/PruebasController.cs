using EvaluacionesOnline.Areas.Seleccion.Models;
using EvaluacionesOnline.Areas.Seleccion.Models.Validator;
using MultiEntidad.A_Seleccion;
using Procedimiento.A_Seleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Elmah;
using Entidad.A_General;
using Procedimiento.A_Sistemas;
using System.IO;


namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    public class PruebasController : BaseModelController<PruebasModel>
    {

        private readonly P_Prueba           _P_Prueba;
        private readonly P_Seguimiento _P_Seguimiento;

        public PruebasController() : base(new PruebasModelValidator())
        {
            this._P_Prueba = new P_Prueba();
            this._P_Seguimiento = new P_Seguimiento();
        }

        public ActionResult V_Pruebas()
        {
            try
            {
                var model = new PruebasModel();

                
                model.mme_prueba.nu_ruta                            = 1;
                model.mme_prueba.me_prueba.candidato.nu_id_usuario  = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                model.ls_mme_prueba = _P_Prueba.Sel(model.mme_prueba);
                
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();                
                ObjEntSeguimiento.nu_id_usuario =           model.mme_prueba.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso =          "PRUEBAS A DESARROLLAR ";
                ObjEntSeguimiento.vc_nom_accion =           "Realizar Evaluación";
                ObjEntSeguimiento.vc_desc_accion =          "Ingreso a la lista de su(s) " + model.ls_mme_prueba.Count().ToString() + " Prueba(s)";
                ObjEntSeguimiento.vc_url_referrer_pagina =  (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina =           (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult V_PruebaPartes(string vc_desc_prueba, decimal? nu_id_prueba = null)
        {
            try
            {
                var model = new PruebasModel();
                ViewBag.NombrePrueba = vc_desc_prueba;
                ViewBag.nu_id_prueba = nu_id_prueba;

                model.mme_prueba.nu_ruta                            = 2;
                model.mme_prueba.me_prueba.candidato.nu_id_usuario  = mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario;
                model.mme_prueba.me_prueba.prueba.nu_id_prueba      = nu_id_prueba;

                model.ls_mme_prueba = _P_Prueba.Sel(model.mme_prueba);

                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = model.mme_prueba.me_prueba.candidato.nu_id_usuario;
                ObjEntSeguimiento.vc_nom_proceso = "PARTES DE LA PRUEBA A DESARROLLAR";
                ObjEntSeguimiento.vc_nom_accion = "Realizar partes de la Prueba";
                ObjEntSeguimiento.vc_desc_accion = "Ingreso a realizar la prueba " + vc_desc_prueba +"";
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult V_PruebaPartePreguntas(string vc_desc_prueba_corta, string vc_desc_prueba, decimal? nu_id_prueba = null, decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba_parte = null, decimal? nu_id_pregunta = null)
        {
            try
            {
                var model = new PruebasModel(); 
                ViewBag.NombrePruebaCorta       = vc_desc_prueba_corta;
                ViewBag.NombrePrueba            = vc_desc_prueba;
                ViewBag.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                ViewBag.nu_id_prueba            = nu_id_prueba;
                ViewBag.nu_id_prueba_parte      = nu_id_prueba_parte;
                ViewBag.ch_tiempo = 0;

                model.mme_prueba.nu_ruta = 3;
                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte          = nu_id_prueba_parte;
                model.mme_prueba.me_prueba.pregunta.nu_id_pregunta                  = nu_id_pregunta;
                model.ls_mme_prueba                                                 = _P_Prueba.Sel(model.mme_prueba);                

                if (model.ls_mme_prueba != null)
                {
                    model.mme_prueba.me_prueba.prueba_candidato.nu_tiempo_transcurrido_segundos = model.ls_mme_prueba[0].me_prueba.prueba_candidato.nu_tiempo_transcurrido_segundos;
                    model.mme_prueba.me_prueba.prueba_candidato.nu_tiempo_transcurrido          = model.ls_mme_prueba[0].me_prueba.prueba_candidato.nu_tiempo_transcurrido;
                    model.mme_prueba.me_prueba.prueba_candidato.progreso_m                      = model.ls_mme_prueba[0].me_prueba.prueba_candidato.progreso_m;
                    model.mme_prueba.me_prueba.prueba.ch_tiempo                                 = model.ls_mme_prueba[0].me_prueba.prueba.ch_tiempo;
                    model.mme_prueba.me_prueba.prueba_parte.vc_instruccion2                     = model.ls_mme_prueba[0].me_prueba.prueba_parte.vc_instruccion2;
                    model.mme_prueba.me_prueba.prueba.nu_id_tipo_prueba                         = model.ls_mme_prueba[0].me_prueba.prueba.nu_id_tipo_prueba;
                }

                if (nu_id_pregunta == null)
                {
                    model.mme_prueba.nu_ruta    = 5;
                    model.ls_preguntas          = _P_Prueba.Sel(model.mme_prueba);
                }

                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = nu_id_prueba_candidato;
                ObjEntSeguimiento.vc_nom_proceso = "DESARROLLO DE PREGUNTAS DE UNA PRUEBA";
                ObjEntSeguimiento.vc_nom_accion =  "Desarrollo de la prueba " + vc_desc_prueba ;
                ObjEntSeguimiento.vc_desc_accion = "Ingreso al desarrollo de la parte {0} ";
                ObjEntSeguimiento.nu_tipo_accion = "1";
                ObjEntSeguimiento.nu_prueba = nu_id_prueba.ToString();
                ObjEntSeguimiento.nu_prueba_parte = nu_id_prueba_parte.ToString();
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult VP_Pregunta(decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba_parte = null, decimal? nu_id_pregunta = null)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.nu_ruta = 3;
                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte          = nu_id_prueba_parte;
                model.mme_prueba.me_prueba.pregunta.nu_id_pregunta                  = nu_id_pregunta;
                model.ls_mme_prueba                                                 = _P_Prueba.Sel(model.mme_prueba);
                model.mme_prueba.me_prueba.prueba.nu_id_tipo_prueba                 = model.ls_mme_prueba[0].me_prueba.prueba.nu_id_tipo_prueba;
                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = nu_id_prueba_candidato;
                ObjEntSeguimiento.vc_nom_proceso = "DESARROLLO DE PREGUNTAS DE UNA PRUEBA";
                ObjEntSeguimiento.vc_nom_accion = "Desarrollo de la prueba {1}  parte {2}";
                ObjEntSeguimiento.vc_desc_accion = "Selecciono la pregunta nro {1}";
                ObjEntSeguimiento.nu_tipo_accion = "3";
                ObjEntSeguimiento.nu_prueba_parte = nu_id_prueba_parte.ToString();
                ObjEntSeguimiento.nu_pregunta = nu_id_pregunta.ToString();
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return PartialView("VP_Pregunta", model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult AC_Respuesta(decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba_parte = null, decimal? nu_id_pregunta = null, decimal? nu_id_alternativa = null)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte = nu_id_prueba_parte;
                model.mme_prueba.me_prueba.pregunta.nu_id_pregunta = nu_id_pregunta;
                model.mme_prueba.me_prueba.alternativa.nu_id_alternativa = nu_id_alternativa;
                model.mme_prueba.me_prueba.alternativa.vc_usr_reg = "Prueba";

                model.mme_prueba.nu_status = int.Parse(_P_Prueba.Set_reset_Respuesta(model.mme_prueba) + "");

                if (model.mme_prueba.nu_status == 1) { 
                    model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato = nu_id_prueba_candidato;
                    model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte = nu_id_prueba_parte;
                    model.mme_prueba.me_prueba.pregunta.nu_id_pregunta = nu_id_pregunta;
                    model.mme_prueba.me_prueba.alternativa.nu_id_alternativa = nu_id_alternativa;
                    model.mme_prueba.me_prueba.alternativa.vc_usr_reg = "Prueba";

                    model.mme_prueba.nu_status = int.Parse(_P_Prueba.Ins(model.mme_prueba) + "");

                    //Inicio Registro de eventos de los candidatos (trazabilidad)
                    E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                    ObjEntSeguimiento.nu_id_usuario = nu_id_prueba_candidato;
                    ObjEntSeguimiento.vc_nom_proceso = "RESPONDER PREGUNTAS DE UNA PRUEBA";
                    ObjEntSeguimiento.vc_nom_accion = "Desarrollo de la Prueba {1} Parte {2}";
                    ObjEntSeguimiento.vc_desc_accion = "De la pregunta: {1} | respondio: {2}";
                    ObjEntSeguimiento.nu_tipo_accion = "2";
                    ObjEntSeguimiento.nu_pregunta = nu_id_pregunta.ToString();
                    ObjEntSeguimiento.nu_respuesta = nu_id_alternativa.ToString();
                    ObjEntSeguimiento.nu_prueba_parte = nu_id_prueba_parte.ToString();
                    ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                    ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                    _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                    //Inicio Registro de eventos de los candidatos (trazabilidad)
                }
                return PartialView("VP_Status", model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult AC_ValidarIngles(decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba_parte = null, decimal? nu_id_option = null)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte          = nu_id_prueba_parte;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_option                = nu_id_option;
                model.mme_prueba.me_prueba.alternativa.vc_usr_reg                   = "Prueba";

                model.mme_prueba.nu_status                                          = int.Parse(_P_Prueba.Validacion_Ingles(model.mme_prueba) + "");
            
                if (model.mme_prueba.nu_status == 1)
                {
                    return Json(new { result = true, message = "1" });
                }
                else
                {
                    return Json(new { result = true, message = "0" });
                }
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult AC_NroPreguntas(decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba_parte = null)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_parte.nu_id_prueba_parte          = nu_id_prueba_parte;
                model.mme_prueba.nu_ruta                                            = 5;
                model.ls_preguntas                                                  = _P_Prueba.Sel(model.mme_prueba);

                return PartialView("VPBtnsPregunta", model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult AC_Terminar(string vc_desc_prueba, decimal? nu_id_prueba_candidato = null, decimal? nu_id_prueba = null)
        {
            try
            {
                
                var model = new PruebasModel();
                ViewBag.NombrePrueba                                                = vc_desc_prueba;
                ViewBag.NuIdPrueba                                                  = nu_id_prueba;
                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.nu_ruta                                            = 6;
                model.mme_prueba.nu_status                                          = _P_Prueba.Upd_Terminar(model.mme_prueba);

                //Inicio Registro de eventos de los candidatos (trazabilidad)
                E_Seguimiento ObjEntSeguimiento = new E_Seguimiento();
                ObjEntSeguimiento.nu_id_usuario = nu_id_prueba_candidato;
                ObjEntSeguimiento.vc_nom_proceso = "DESARROLLO DE PREGUNTAS DE UNA PRUEBA";
                ObjEntSeguimiento.vc_nom_accion = "Desarrollo de la prueba " + vc_desc_prueba + "  parte {1}";
                ObjEntSeguimiento.vc_desc_accion = "Se termino la prueba";
                ObjEntSeguimiento.nu_tipo_accion = "4";
                ObjEntSeguimiento.nu_prueba = nu_id_prueba.ToString();
                ObjEntSeguimiento.nu_prueba_parte = nu_id_prueba_candidato.ToString();
                ObjEntSeguimiento.vc_url_referrer_pagina = (HttpContext.Request.UrlReferrer == null) ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri.ToString();
                ObjEntSeguimiento.vc_url_pagina = (HttpContext.Request.Url == null) ? "" : HttpContext.Request.Url.AbsoluteUri.ToString();
                _P_Seguimiento.Set_Seguimiento(ObjEntSeguimiento);
                //Inicio Registro de eventos de los candidatos (trazabilidad)

                return PartialView("VP_ExamenFinalizado", model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        [HttpPost]
        public ActionResult AC_Tiempo(decimal? nu_id_prueba_candidato = null, decimal? progreso_m = null, decimal? progreso_s = null)
        {
            try
            {
                var model = new PruebasModel();
                model.mme_prueba.me_prueba.prueba_candidato.nu_id_prueba_candidato  = nu_id_prueba_candidato;
                model.mme_prueba.me_prueba.prueba_candidato.progreso_m              = progreso_m;
                model.mme_prueba.me_prueba.prueba_candidato.progreso_s              = progreso_s;
                model.mme_prueba.nu_status                                          = _P_Prueba.Upd_Tiempo(model.mme_prueba);

                return Json(new{result = true, message = "Tiempo transcurrido actualizado" });
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }
        
        public ActionResult CF_LoadFile(decimal id_prueba_candidato, decimal id_pregunta, decimal id_prueba, decimal id_prueba_parte )
        {
            // Checking no of files injected in Request object
            if (Request.Files.Count > 0)
            {
                try
                {
                   String vc_nomfile_respuesta = "";
                   // Get all files from Request object
                   HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + “Uploads/”;
                        //string filename = Path.GetFileName(Request.Files[i].FileName);
                        HttpPostedFileBase file = files[i];
                        string fname;
                        // Checking for Internet Explorer
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        fname = "PruebaRespuesta_" + id_prueba_candidato + id_prueba + Path.GetExtension(fname);
                        vc_nomfile_respuesta = fname;
                        // Get the complete folder path and store the file inside it.
                        var FolderPath = Server.MapPath("~/Archivos/");
                        if (!Directory.Exists(FolderPath))
                        {
                            // Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(FolderPath);
                        }
                        fname = Path.Combine(FolderPath, fname);
                        file.SaveAs(fname);
                    }
                    int ReturnState = _P_Prueba.Set_RespuestaFile(id_prueba_candidato, id_pregunta, id_prueba_parte, vc_nomfile_respuesta, mme_session.MME_Sesion.me_prueba.candidato.nu_id_usuario.ToString());
                    // Returns message that successfully uploaded
                    return Json("OK");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred.Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
            //return Json(new { idPuesto = idPuesto, estado = "OK" }); ;
        }
    }
}
