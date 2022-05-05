using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_Seleccion
{
    [Serializable]
    public partial class E_Prueba_Parte
    {
        public decimal? nu_id_prueba_parte      { get; set; }
        public decimal? nu_id_prueba            { get; set; }
        public decimal? nu_nro_parte            { get; set; }
        public string   vc_desc_prueba_parte    { get; set; }
        public decimal? nu_tiempo_limite_min    { get; set; }
        public string   vc_usr_reg              { get; set; }
        public string   vc_usr_mod              { get; set; }
        public string   ch_status               { get; set; }

        public decimal? nu_id_option            { get; set; }

        public string   vc_instruccion1         { get; set; }
        public string   vc_instruccion2         { get; set; }
    }
}
