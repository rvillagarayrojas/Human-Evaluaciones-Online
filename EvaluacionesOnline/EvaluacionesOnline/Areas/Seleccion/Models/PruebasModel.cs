using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web;
using MultiEntidad.A_Seleccion;

namespace EvaluacionesOnline.Areas.Seleccion.Models
{
    public class PruebasModel
    {
        public MME_Prueba           mme_prueba      { get; set; }
        public List<MME_Prueba>     ls_mme_prueba   { get; set; }
        public List<MME_Prueba>     ls_preguntas    { get; set; }
        
        public List<MME_Prueba>     ls_educacion            { get; set; }
        public List<MME_Prueba>     ls_conocimiento         { get; set; }
        public List<MME_Prueba>     ls_experiencia_laboral  { get; set; }
        public List<MME_Prueba>     ls_familiares           { get; set; }

        public List<MME_Prueba>     ls_candidatos   { get; set; }
        public List<MME_Prueba>     ls_wonderlik    { get; set; }
        public List<MME_Prueba>     ls_gatb         { get; set; }
        public List<MME_Prueba>     ls_ic           { get; set; }
        public List<MME_Prueba>     ls_disc         { get; set; }
        public List<MME_Prueba>     ls_cps          { get; set; }
        public List<MME_Prueba>     ls_kostick      { get; set; }
        public MME_Prueba           mme_datos       { get; set; }

        public PruebasModel()
        {
            this.mme_prueba     = new MME_Prueba();
            this.ls_mme_prueba  = new List<MME_Prueba>();
            this.ls_preguntas   = new List<MME_Prueba>();

            this.ls_educacion           = new List<MME_Prueba>();
            this.ls_conocimiento        = new List<MME_Prueba>();
            this.ls_experiencia_laboral = new List<MME_Prueba>();
            this.ls_familiares          = new List<MME_Prueba>();

            this.ls_candidatos  = new List<MME_Prueba>();
            this.ls_wonderlik   = new List<MME_Prueba>();
            this.ls_gatb        = new List<MME_Prueba>();
            this.ls_ic          = new List<MME_Prueba>();
            this.ls_disc        = new List<MME_Prueba>();
            this.ls_cps         = new List<MME_Prueba>();
            this.ls_kostick     = new List<MME_Prueba>();
            this.mme_datos      = new MME_Prueba();
        }
    }
}