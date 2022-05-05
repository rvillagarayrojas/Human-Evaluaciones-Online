using Entidad.A_Seleccion;
using Entidad.A_General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroEntidad.A_Seleccion
{
    public class ME_Prueba
    {
        public E_Prueba                 prueba                  { get; set; }
        public E_Prueba_Parte           prueba_parte            { get; set; }
        public E_Pregunta               pregunta                { get; set; }
        public E_Alternativa            alternativa             { get; set; }
        public E_Prueba_Candidato       prueba_candidato        { get; set; }
        public E_Candidato              candidato               { get; set; }
        public E_Candidato_Evaluacion   candidato_evaluacion    { get; set; }
        public E_Reporte_Conocimiento   reporte_conocimiento    { get; set; }
        public E_Educacion              educacion               { get; set; }
        public E_Conocimiento           conocimiento            { get; set; }
        public E_Experiencia_Laboral    experiencia_laboral     { get; set; }
        public E_Familiares             familiares              { get; set; }

        public List<E_Educacion>            EducacionDetalle        { get; set; }
        public List<E_Conocimiento>         ConocimientoDetalle     { get; set; }
        public List<E_Experiencia_Laboral>  ExperienciaDetalle      { get; set; }
        public List<E_Familiares>           FamiliaresDetalle       { get; set; }

        public ME_Prueba()
        {
            this.prueba                 = new E_Prueba();
            this.prueba_parte           = new E_Prueba_Parte();
            this.pregunta               = new E_Pregunta();
            this.alternativa            = new E_Alternativa();
            this.prueba_candidato       = new E_Prueba_Candidato();
            this.candidato              = new E_Candidato();
            this.candidato_evaluacion   = new E_Candidato_Evaluacion();
            this.reporte_conocimiento   = new E_Reporte_Conocimiento();
            this.educacion              = new E_Educacion();
            this.conocimiento           = new E_Conocimiento();
            this.experiencia_laboral    = new E_Experiencia_Laboral();
            this.familiares             = new E_Familiares();

            this.EducacionDetalle       = new List<E_Educacion>();
            this.ConocimientoDetalle    = new List<E_Conocimiento>();
            this.ExperienciaDetalle     = new List<E_Experiencia_Laboral>();
            this.FamiliaresDetalle      = new List<E_Familiares>();
        }

    }
}
