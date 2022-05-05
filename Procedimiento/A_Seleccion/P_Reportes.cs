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

namespace Procedimiento.A_Seleccion
{
    public class P_Reportes
    {
        T_Reportes _T_Reportes;

        public P_Reportes()
        {
            _T_Reportes = new T_Reportes();
        }

        public List<MME_Prueba> Sel_Candidatos_Evaluacion(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Sel_Candidatos_Evaluacion(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Wonderlik(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Wonderlic(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Gatb(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Gatb(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Ic(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Ic(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Disc(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Disc(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Cps(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Cps(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public List<MME_Prueba> Sel_Prc_Kostick(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Reportes.Get_Prc_Kostick(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }
    }
}
