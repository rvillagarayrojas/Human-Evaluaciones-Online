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
    public class P_Prueba
    {
        T_Prueba _T_Prueba;

        public P_Prueba()
        {
            _T_Prueba = new T_Prueba();
        }

        public List<MME_Prueba> Sel(MME_Prueba modelo)
        {
            List<MME_Prueba> ListaModeloEntidad = null;
            try
            {
                switch(modelo.nu_ruta)
                {
                    case 1: ListaModeloEntidad = _T_Prueba.Sel_Prueba(modelo); break;
                    case 2: ListaModeloEntidad = _T_Prueba.Sel_Prueba_Parte(modelo); break;
                    case 3: ListaModeloEntidad = _T_Prueba.Get_Pregunta(modelo); break;
                    case 5: ListaModeloEntidad = _T_Prueba.Sel_Nro_Preguntas(modelo); break;
                }
                if (modelo.nu_ruta == 3)
                {   
                    foreach(var item in ListaModeloEntidad)
                    {
                        item.me_prueba.prueba_candidato.nu_id_prueba_candidato = modelo.me_prueba.prueba_candidato.nu_id_prueba_candidato;
                        item.nu_ruta = 4;                        
                    }
                    ListaModeloEntidad = _T_Prueba.Sel_Alternativa(ListaModeloEntidad);
                }
            }
            catch (Exception ex) { throw ex; }
            return ListaModeloEntidad;
        }

        public int Ins(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Ins_Respuesta(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int Set_reset_Respuesta(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Set_reset_Respuesta(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        

        public int Validacion_Ingles(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Validacion_Ingles(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int Upd_Tiempo(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Upd_Tiempo(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }

        public int Set_RespuestaFile(decimal NU_ID_PRUEBA_CANDIDATO, decimal NU_ID_PREGUNTA, decimal NU_ID_PRUEBA_PARTE, String VC_NOMFILE_RESPUESTA, String VC_COD_USUARIO)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Set_RespuestaFile(NU_ID_PRUEBA_CANDIDATO, NU_ID_PREGUNTA, NU_ID_PRUEBA_PARTE, VC_NOMFILE_RESPUESTA, VC_COD_USUARIO);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }
        
        public int Upd_Terminar(MME_Prueba modelo)
        {
            var status = 0;
            try
            {
                status = _T_Prueba.Upd_Terminar(modelo);
            }
            catch (Exception ex) { throw ex; }
            return status;
        }
    }
}
