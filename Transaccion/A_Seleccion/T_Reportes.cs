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

namespace Transaccion.A_Seleccion
{
    public class T_Reportes : SqlCn
    {

        public List<MME_Prueba> Sel_Candidatos_Evaluacion(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_sel_candidatos_evaluacion"))
                {
                    db.AddInParameter(cmd, "@vc_dato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_dato);

                    return LsMme(db.ExecuteReader(cmd), 0);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Wonderlic(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_wonderlik"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 1);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Gatb(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_gatb"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 11);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Ic(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_ic"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 111);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Disc(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_disc_maximo"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 2);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Cps(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_cps"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 3);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public List<MME_Prueba> Get_Prc_Kostick(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_prc_kostick"))
                {
                    db.AddInParameter(cmd, "@nu_id_candidato", DbType.Decimal, mme.me_prueba.reporte_conocimiento.nu_id_candidato);

                    return LsMme(db.ExecuteReader(cmd), 4);
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
            if(Ruta == 0)
            {
                mme.me_prueba.candidato_evaluacion.nu_id_candidato                  = oR["nu_id_candidato"].ToDecimal();
                mme.me_prueba.candidato_evaluacion.vc_nombres_candidato             = oR["vc_nombres_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_doc_identi                    = oR["vc_doc_identi"].ToText();
                mme.me_prueba.candidato_evaluacion.nu_edad_candidato                = oR["nu_edad_candidato"].ToInt32();
                mme.me_prueba.candidato_evaluacion.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_profesion_candidato           = oR["vc_profesion_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_empresa_candidato             = oR["vc_empresa_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_ultima_experiencia_candidato  = oR["vc_ultima_experiencia_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato   = oR["vc_nombre_referencia_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato = oR["vc_telefono_referencia_candidato"].ToText();
                mme.me_prueba.candidato_evaluacion.vc_consultor                     = oR["vc_consultor"].ToText();
            }

            if(Ruta == 1)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor_esperado          = oR["nu_rango_menor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor_esperado          = oR["nu_rango_mayor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor                   = oR["nu_rango_menor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor                   = oR["nu_rango_mayor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_parametro_obtenido            = oR["nu_parametro_obtenido"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_diagnostico              = oR["vc_desc_diagnostico"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_recomendacion                 = oR["vc_recomendacion"].ToText();
            }

            if(Ruta == 11)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor_esperado          = oR["nu_rango_menor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor_esperado          = oR["nu_rango_mayor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor                   = oR["nu_rango_menor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor                   = oR["nu_rango_mayor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_parametro_obtenido            = oR["nu_parametro_obtenido"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_parametro_obtenido_v          = oR["nu_parametro_obtenido_v"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_parametro_obtenido_n          = oR["nu_parametro_obtenido_n"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_diagnostico              = oR["vc_desc_diagnostico"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_recomendacion                 = oR["vc_recomendacion"].ToText();
            }

            if(Ruta == 111)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor_esperado          = oR["nu_rango_menor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor_esperado          = oR["nu_rango_mayor_esperado"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_menor                   = oR["nu_rango_menor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_rango_mayor                   = oR["nu_rango_mayor"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_parametro_obtenido            = oR["nu_parametro_obtenido"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_diagnostico              = oR["vc_desc_diagnostico"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_recomendacion                 = oR["vc_recomendacion"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_categoria_esperada            = oR["nu_categoria_esperada"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_categoria_obtenida            = oR["nu_categoria_obtenida"].ToDecimal();
            }

            if(Ruta == 2)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                
                mme.me_prueba.reporte_conocimiento.vc_patron_disc                   = oR["vc_patron_disc"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_descripcion_patron            = oR["vc_descripcion_patron"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_caracteristica                = oR["vc_caracteristica"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_caracteristica           = oR["vc_desc_caracteristica"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();

                mme.me_prueba.reporte_conocimiento.nu_valor_d                       = oR["nu_valor_d"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_valor_i                       = oR["nu_valor_i"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_valor_s                       = oR["nu_valor_s"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_valor_c                       = oR["nu_valor_c"].ToDecimal();

            }

            if(Ruta == 3)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();

                mme.me_prueba.reporte_conocimiento.vc_parametro_cps                 = oR["vc_parametro_cps"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_marcadas                      = oR["nu_marcadas"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.nu_valor_s                       = oR["nu_valor_s"].ToDecimal();
            }

            if(Ruta == 4)
            {
                mme.me_prueba.reporte_conocimiento.vc_candidato                     = oR["vc_candidato"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_edad                          = oR["nu_edad"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_grado_instruccion             = oR["vc_grado_instruccion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_profesion                     = oR["vc_profesion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_empresa                       = oR["vc_empresa"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_ultima_experiencia            = oR["vc_ultima_experiencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia            = oR["vc_nombres_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia           = oR["vc_telefono_referencia"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_nombres_referencia2           = oR["vc_nombres_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_telefono_referencia2          = oR["vc_telefono_referencia2"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_consultor                     = oR["vc_consultor"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_prueba                   = oR["vc_desc_prueba"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_esperada   = oR["vc_desc_clasificacion_esperada"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_puesto                   = oR["vc_desc_puesto"].ToText();

                mme.me_prueba.reporte_conocimiento.vc_letra_parametro               = oR["vc_letra_parametro"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_desc_clasificacion_obtenida   = oR["vc_desc_clasificacion_obtenida"].ToText();
                mme.me_prueba.reporte_conocimiento.nu_marcadas                      = oR["nu_marcadas"].ToDecimal();
                mme.me_prueba.reporte_conocimiento.vc_desc_perfil                   = oR["vc_desc_perfil"].ToText();

                mme.me_prueba.reporte_conocimiento.vc_area_evaluada                 = oR["vc_descripcion"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_positivo                      = oR["vc_positivo"].ToText();
                mme.me_prueba.reporte_conocimiento.vc_negativo                      = oR["vc_negativo"].ToText();
            }
            return mme;
        }
    }
}
