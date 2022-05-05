using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_Seleccion
{
    [Serializable]
    public partial class E_Alternativa
    {
        public decimal? nu_id_alternativa       { get; set; }
        public decimal? nu_id_pregunta          { get; set; }
        public decimal? nu_nro_alternativa      { get; set; }
        public decimal? nu_division             { get; set; }
        public string   vc_desc_alternativa     { get; set; }
        public string   vc_desc_imagen          { get; set; }
        public string   ch_tipo_alternativa     { get; set; }
        public string   ch_presentacion         { get; set; }
        public string   ch_orientacion          { get; set; }
        public string   vc_usr_reg              { get; set; }
        public string   vc_usr_mod              { get; set; }
        public string   ch_status               { get; set; }
        public string   vc_desc_parametro       { get; set; }

        public string   ch_marca                { get; set; }
    }
}
