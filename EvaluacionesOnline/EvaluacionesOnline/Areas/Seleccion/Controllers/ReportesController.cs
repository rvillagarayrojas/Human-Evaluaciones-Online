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

namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    public class ReportesController : BaseModelController<PruebasModel>
    {

        private readonly P_Reportes _P_Reportes;

        public ReportesController() : base(new PruebasModelValidator())
        {
            this._P_Reportes = new P_Reportes();
        }

        public ActionResult V_Informe()
        {
            try
            {
                var model = new PruebasModel();
                model.mme_prueba.me_prueba.candidato_evaluacion.vc_dato = "";
                model.ls_candidatos = _P_Reportes.Sel_Candidatos_Evaluacion(model.mme_prueba);
                return View(model); 
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult VP_Candidatos(string dato)
        {
            try
            {
                var model = new PruebasModel();
                model.mme_prueba.me_prueba.candidato_evaluacion.vc_dato = dato;
                model.ls_candidatos = _P_Reportes.Sel_Candidatos_Evaluacion(model.mme_prueba);
                return PartialView("VP_Candidatos",model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult V_Reporte_Completo(int id)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.reporte_conocimiento.nu_id_candidato = id;

                model.ls_wonderlik = _P_Reportes.Sel_Prc_Wonderlik(model.mme_prueba);
                if (model.ls_wonderlik.Count > 0) { model.mme_datos = DatosPersonales(model.ls_wonderlik[0]); }

                model.ls_gatb = _P_Reportes.Sel_Prc_Gatb(model.mme_prueba);
                if (model.ls_gatb.Count > 0) { model.mme_datos = DatosPersonales(model.ls_gatb[0]); }

                model.ls_ic = _P_Reportes.Sel_Prc_Ic(model.mme_prueba);
                if (model.ls_ic.Count > 0) { model.mme_datos = DatosPersonales(model.ls_ic[0]); }

                model.ls_disc = _P_Reportes.Sel_Prc_Disc(model.mme_prueba);
                if (model.ls_disc.Count > 0) { model.mme_datos = DatosPersonales(model.ls_disc[0]); }

                model.ls_cps = _P_Reportes.Sel_Prc_Cps(model.mme_prueba);
                if (model.ls_cps.Count > 0) { model.mme_datos = DatosPersonales(model.ls_cps[0]); }

                model.ls_kostick = _P_Reportes.Sel_Prc_Kostick(model.mme_prueba);
                if (model.ls_kostick.Count > 0) { model.mme_datos = DatosPersonales(model.ls_kostick[0]); }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult V_Reporte_Resumen(int id)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.reporte_conocimiento.nu_id_candidato = id;

                model.ls_wonderlik = _P_Reportes.Sel_Prc_Wonderlik(model.mme_prueba);
                if (model.ls_wonderlik.Count > 0) { model.mme_datos = DatosPersonales(model.ls_wonderlik[0]); }

                model.ls_gatb = _P_Reportes.Sel_Prc_Gatb(model.mme_prueba);
                if (model.ls_gatb.Count > 0) { model.mme_datos = DatosPersonales(model.ls_gatb[0]); }

                model.ls_ic = _P_Reportes.Sel_Prc_Ic(model.mme_prueba);
                if (model.ls_ic.Count > 0) { model.mme_datos = DatosPersonales(model.ls_ic[0]); }

                model.ls_disc = _P_Reportes.Sel_Prc_Disc(model.mme_prueba);
                if (model.ls_disc.Count > 0) { model.mme_datos = DatosPersonales(model.ls_disc[0]); }

                model.ls_cps = _P_Reportes.Sel_Prc_Cps(model.mme_prueba);
                if (model.ls_cps.Count > 0) { model.mme_datos = DatosPersonales(model.ls_cps[0]); }

                model.ls_kostick = _P_Reportes.Sel_Prc_Kostick(model.mme_prueba);
                if (model.ls_kostick.Count > 0) { model.mme_datos = DatosPersonales(model.ls_kostick[0]); }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public ActionResult V_Reporte_Grafico(int id)
        {
            try
            {
                var model = new PruebasModel();

                model.mme_prueba.me_prueba.reporte_conocimiento.nu_id_candidato = id;

                model.ls_wonderlik = _P_Reportes.Sel_Prc_Wonderlik(model.mme_prueba);
                if (model.ls_wonderlik.Count > 0) { model.mme_datos = DatosPersonales(model.ls_wonderlik[0]); }

                model.ls_gatb = _P_Reportes.Sel_Prc_Gatb(model.mme_prueba);
                if (model.ls_gatb.Count > 0) { model.mme_datos = DatosPersonales(model.ls_gatb[0]); }

                model.ls_ic = _P_Reportes.Sel_Prc_Ic(model.mme_prueba);
                if (model.ls_ic.Count > 0) { model.mme_datos = DatosPersonales(model.ls_ic[0]); }

                model.ls_disc = _P_Reportes.Sel_Prc_Disc(model.mme_prueba);
                if (model.ls_disc.Count > 0) { model.mme_datos = DatosPersonales(model.ls_disc[0]); }

                model.ls_cps = _P_Reportes.Sel_Prc_Cps(model.mme_prueba);
                if (model.ls_cps.Count > 0) { model.mme_datos = DatosPersonales(model.ls_cps[0]); }

                model.ls_kostick = _P_Reportes.Sel_Prc_Kostick(model.mme_prueba);
                if (model.ls_kostick.Count > 0) { model.mme_datos = DatosPersonales(model.ls_kostick[0]); }

                return View(model);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }

        public MME_Prueba DatosPersonales(MME_Prueba Datos)
        {
            try
            {
                return Datos;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }
            
        }
    }
}
