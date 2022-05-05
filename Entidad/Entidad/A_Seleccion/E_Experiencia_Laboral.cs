using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.A_Seleccion
{
    public class E_Experiencia_Laboral
    {
        public int?         nu_id_experiencia  { get; set; }
        public int?         nu_id_persona      { get; set; }
        public string       vc_nombre_empresa  { get; set; }
        public string       vc_puesto          { get; set; }
        public DateTime?    dt_fec_inicio      { get; set; }
        public DateTime?    dt_fec_fin         { get; set; }
        public decimal?     nu_importe_sueldo  { get; set; }
        public string       vc_motivo_retiro   { get; set; }

    }
}
