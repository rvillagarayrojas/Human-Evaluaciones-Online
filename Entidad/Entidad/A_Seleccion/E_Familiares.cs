using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.A_Seleccion
{
    public class E_Familiares
    {
        public int?     nu_id_familiares        { get; set; }
        public int?     nu_id_persona           { get; set; }
        public string   vc_apellidos_nombres    { get; set; }
        public string   vc_edad                 { get; set; }
        public string   vc_grado_academico      { get; set; }
        public string   vc_centro_trabajo       { get; set; }
        public string   vc_ocupacion            { get; set; }
        public string   vc_parentesco           { get; set; }
    }
}
