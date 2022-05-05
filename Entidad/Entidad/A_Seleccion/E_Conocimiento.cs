using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.A_Seleccion
{
    public class E_Conocimiento
    {
        public int?     nu_id_conocimiento          { get; set; }
        public int?     nu_id_persona               { get; set; }
        public string   vc_desc_conocimiento        { get; set; }
        public string   vc_nivel_conocimiento       { get; set; }
        public string   vc_desc_capacidad           { get; set; }
    }
}
