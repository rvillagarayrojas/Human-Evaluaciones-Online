using Conexiones.SQLServer;
using MultiEntidad.A_Seleccion;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaccion.A_Seleccion;
using Transaccion.A_Sistemas;

namespace Procedimiento.A_Sistemas
{
    public class P_Acceso
    {
        T_Acceso _T_Acceso;

        public P_Acceso()
        {
            _T_Acceso = new T_Acceso();
        }

        public string Get_Acesso(MME_Prueba modelo)
        {
            string mensaje = null;
            try
            {
                mensaje = _T_Acceso.Get_Acceso(modelo);
            }
            catch (Exception ex) { throw ex; }
            return mensaje;
        }

        public List<MME_Prueba> Get_Datos(MME_Prueba modelo)
        {
            List<MME_Prueba> List = new List<MME_Prueba>();
            try
            {
                List = _T_Acceso.Get_Datos(modelo);
            }
            catch (Exception ex) { throw ex; }
            return List;
        }
    }
}
