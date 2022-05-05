using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.A_General
{
    public class E_Seguimiento
    {
        public decimal? nu_id_usuario { get; set; }
        public string vc_cod_usuario { get; set; }
        public string vc_nom_proceso { get; set; }
        public string vc_nom_accion { get; set; }
        public string vc_desc_accion { get; set; }
        public string vc_url_referrer_pagina { get; set; }
        public string vc_url_pagina { get; set; }        
        public DateTime dt_fecha_accion { get; set; }
        public string nu_tipo_accion { get; set; }        
        public string nu_prueba { get; set; }        
        public string nu_prueba_parte { get; set; }        
        public string nu_pregunta { get; set; }        
        public string nu_respuesta { get; set; }        
        
    }
}
