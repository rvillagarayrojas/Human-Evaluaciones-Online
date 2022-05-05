using Entidad.A_General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaccion.A_Sistemas;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Procedimiento.A_Sistemas
{
    public class P_Seguimiento
    {
        T_Seguimiento _T_Seguimiento;

        public P_Seguimiento()
        {
            _T_Seguimiento = new T_Seguimiento();
        }

        public string Set_Seguimiento(E_Seguimiento E_modelo)
        {
            string mensaje = null;
            try
            {
                mensaje = _T_Seguimiento.Set_Seguimiento(E_modelo);
            }
            catch (Exception ex) { throw ex; }
            return mensaje;
        }
    }
}
