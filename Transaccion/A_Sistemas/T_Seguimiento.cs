using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexiones.SQLServer;
using System.Data;
using System.Data.Common;
using Entidad.A_General;

namespace Transaccion.A_Sistemas
{
    public class T_Seguimiento : SqlCn
    {


        public string Set_Seguimiento(E_Seguimiento E_Seg)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_set_seguimiento"))
                {
                    db.AddOutParameter(cmd,"@vc_mensaje_out", DbType.String, 300);
                    db.AddInParameter(cmd, "@nu_id_usuario", DbType.String, E_Seg.nu_id_usuario);                  
                    db.AddInParameter(cmd, "@vc_nom_proceso", DbType.String, E_Seg.vc_nom_proceso);
                    db.AddInParameter(cmd, "@vc_nom_accion", DbType.String, E_Seg.vc_nom_accion);
                    db.AddInParameter(cmd, "@vc_desc_accion", DbType.String, E_Seg.vc_desc_accion);
                    db.AddInParameter(cmd, "@vc_url_referrer_pagina", DbType.String, E_Seg.vc_url_referrer_pagina);
                    db.AddInParameter(cmd, "@vc_url_pagina", DbType.String, E_Seg.vc_url_pagina);
                    db.AddInParameter(cmd, "@nu_tipo_accion", DbType.String, E_Seg.nu_tipo_accion);
                    db.AddInParameter(cmd, "@nu_prueba", DbType.String, E_Seg.nu_prueba);
                    db.AddInParameter(cmd, "@nu_prueba_parte", DbType.String, E_Seg.nu_prueba_parte);
                    db.AddInParameter(cmd, "@nu_pregunta", DbType.String, E_Seg.nu_pregunta);
                    db.AddInParameter(cmd, "@nu_respuesta", DbType.String, E_Seg.nu_respuesta);                  

                    db.ExecuteNonQuery(cmd);
                    string mensaje = db.GetParameterValue(cmd, "@vc_mensaje_out").ToString();
                    return mensaje;
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
