using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.A_Seleccion
{
    public class E_Educacion
    {
        public int?     nu_id_educacion         { get; set; }
        public int?     nu_id_persona           { get; set; }
        public string   vc_desc_nivel_estudio   { get; set; }
        public string   vc_desc_especialidad    { get; set; }
        public string   vc_centro_estudio       { get; set; }
        public string   vc_anio_egreso          { get; set; }
        public string   vc_titulo_obtenido      { get; set; }
        public string   vc_ciclos_cursados      { get; set; }
    }
}
