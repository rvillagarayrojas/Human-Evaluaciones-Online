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
    public class P_Candidato_Evaluacion
    {
        T_Candidato_Evaluacion _T_Candidato_Evaluacion;

        public P_Candidato_Evaluacion()
        {
            _T_Candidato_Evaluacion = new T_Candidato_Evaluacion();
        }

        public List<MME_Prueba> Sel(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                ListaModeloEntidad = _T_Candidato_Evaluacion.Get_Candidato_Evaluacion(modelo);
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public int Upd_Candidato_Evaluacion(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Upd_Candidato_Evaluacion(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int Upd_Candidato_Evaluacion_ficha(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Upd_Candidato_Evaluacion_Ficha(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int Ins(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Ins_Conocimiento(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }
        
        public int InsEducacion(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Ins_Educacion(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int InsExperienciaLaboral(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Ins_ExperienciaLaboral(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int InsFamiliares(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Candidato_Evaluacion.Ins_Familiares(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }
    }
}
