using Conexiones.SQLServer;
using MultiEntidad.A_Seleccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaccion.Recursos;
using System.Configuration;

namespace Transaccion.A_Sistemas
{
    public class T_Acceso : SqlCn
    {
        public string Get_Acceso(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_get_acceso"))
                {
                    db.AddOutParameter(cmd, "@vc_mensaje", DbType.String,300);
                    db.AddInParameter(cmd, "@vc_cod_usuario", DbType.String, mme.me_prueba.candidato.vc_cod_usuario);
                    db.AddInParameter(cmd, "@vc_password", DbType.String, mme.me_prueba.candidato.vc_password);
                    db.ExecuteNonQuery(cmd);
                    string mensaje = db.GetParameterValue(cmd,"@vc_mensaje").ToString();
                    return mensaje;
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Datos(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_get_usuario_candidato"))
                {
                    db.AddInParameter(cmd, "@nu_id_usuario", DbType.String, mme.me_prueba.candidato.nu_id_usuario);
                    return LsMme(db.ExecuteReader(cmd), mme.nu_ruta);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private List<MME_Prueba> LsMme(IDataReader oR, decimal? Ruta = null)
        {
            var ls_mme = new List<MME_Prueba>();
            while (oR.Read())
            {
                ls_mme.Add(Mme(oR, Ruta));
            }
            return ls_mme;
        }

        private MME_Prueba Mme(IDataReader oR, decimal? Ruta = null)
        {
            var mme = new MME_Prueba();

            mme.me_prueba.candidato.vc_nombres              = oR["vc_nombres"].ToText();
            mme.me_prueba.candidato.nu_id_perfil            = oR["nu_id_perfil"].ToDecimal();
            mme.me_prueba.candidato.VC_IMAGEN_PERSONALIZAR  = oR["VC_IMAGEN_PERSONALIZAR"].ToText();            
            return mme;
        }
    }
}
