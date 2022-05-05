using MacroEntidad.A_Seleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiEntidad.A_Seleccion
{
    public class MME_Prueba
    {
        public int?             nu_ruta         { get; set; }
        public int?             nu_status       { get; set; }
        public ME_Prueba        me_prueba       { get; set; }
        public List<MME_Prueba> ls_mme_prueba   { get; set; }

        public MME_Prueba()
        {
            this.me_prueba      = new ME_Prueba();
            this.ls_mme_prueba  = new List<MME_Prueba>();
        }
    }
}
