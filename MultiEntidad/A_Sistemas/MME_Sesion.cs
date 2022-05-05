using MacroEntidad.A_Seleccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiEntidad.A_Sistemas
{
    public class MME_Sesion
    {
        public ME_Prueba        me_prueba       { get; set; }

        public MME_Sesion()
        {
            this.me_prueba      = new ME_Prueba();
        }
    }
}
