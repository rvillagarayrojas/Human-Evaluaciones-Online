using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_Seleccion
{
    [Serializable]
    public partial class E_Prueba_Candidato
    {
        public decimal?     nu_id_prueba_candidato          { get; set; }
        public decimal?     nu_id_prueba                    { get; set; }
        public decimal?     nu_id_prueba_parte              { get; set; }
        public decimal?     nu_id_consultor                 { get; set; }
        public decimal?     nu_id_candidato                 { get; set; }
        public decimal?     nu_id_puesto                    { get; set; }
        public decimal?     nu_tiempo_transcurrido          { get; set; }
        public decimal?     nu_tiempo_transcurrido_segundos { get; set; }
        public decimal?     progreso_m                      { get; set; }
        public decimal?     progreso_s                      { get; set; }
        public decimal?     nu_ultimo_nro_pregunta          { get; set; }
        public DateTime?    dt_fec_evaluacion               { get; set; }
        public string       ch_estado                       { get; set; }
        public string       vc_usr_reg                      { get; set; }
        public string       vc_usr_mod                      { get; set; }
        public string       ch_status                       { get; set; }
        public DateTime?    dt_fec_ini                      { get; set; }
        public DateTime?    dt_fec_fin                      { get; set; }
    }
}
