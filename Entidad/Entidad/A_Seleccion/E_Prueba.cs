using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_Seleccion
{
    [Serializable]
    public partial class E_Prueba
    {
        public decimal? nu_id_prueba            { get; set; }
        public decimal? nu_id_tipo_prueba       { get; set; }
        public string   vc_desc_prueba          { get; set; }
        public string   vc_desc_tipo_prueba     { get; set; }
        public string   vc_desc_observacion     { get; set; }
        public string   vc_usr_reg              { get; set; }
        public string   vc_usr_mod              { get; set; }
        public string   ch_status               { get; set; }


        public decimal? nu_nro_preguntas        { get; set; }
        public decimal? nu_nro_partes           { get; set; }
        public string   ch_tiempo               { get; set; }
        public string ch_estado_prueba          { get; set; }

        public string dt_hora_inicio            { get; set; }

        public decimal? nu_publica { get; set; }
        public string vc_nomfile { get; set; }

    }
}
