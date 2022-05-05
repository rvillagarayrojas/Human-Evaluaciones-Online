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
    public class T_Candidato_Evaluacion : SqlCn
    {
        public List<MME_Prueba> Get_Candidato_Evaluacion(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                using (cmd = db.GetStoredProcCommand("sp_get_candidato_evaluacion"))
                {
                    db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);

                    return LsMme(db.ExecuteReader(cmd), mme.nu_ruta);
                }
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public int Upd_Candidato_Evaluacion(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_upd_candidato_evaluacion");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_nombres_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombres_candidato.ToUpper());
                db.AddInParameter(cmd, "@vc_apellidos_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_apellidos_candidato.ToUpper());
                db.AddInParameter(cmd, "@ch_sexo_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_sexo_candidato);
                db.AddInParameter(cmd, "@nu_edad_candidato", DbType.Decimal, mme.me_prueba.candidato_evaluacion.nu_edad_candidato);
                db.AddInParameter(cmd, "@vc_profesion_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_profesion_candidato);
                db.AddInParameter(cmd, "@vc_ultima_experiencia_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_ultima_experiencia_candidato);
                db.AddInParameter(cmd, "@vc_empresa_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_empresa_candidato);
                db.AddInParameter(cmd, "@nu_sueldo_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.nu_sueldo_candidato);
                db.AddInParameter(cmd, "@vc_nombre_referencia_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato.ToUpper());
                db.AddInParameter(cmd, "@vc_telefono_referencia_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato);
                db.AddInParameter(cmd, "@vc_nombre_referencia_candidato2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato2);
                db.AddInParameter(cmd, "@vc_telefono_referencia_candidato2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato2);
                db.AddInParameter(cmd, "@nu_id_grado_instruccion", DbType.String, mme.me_prueba.candidato_evaluacion.nu_id_grado_instruccion);
                db.AddInParameter(cmd, "@vc_usr_mod", DbType.String, mme.me_prueba.candidato_evaluacion.vc_usr_mod);
                db.ExecuteNonQuery(cmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public int Upd_Candidato_Evaluacion_Ficha(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_upd_candidato_evaluacion_ficha");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_nombres_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombres_candidato.ToUpper());
                db.AddInParameter(cmd, "@vc_apellidos_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_apellidos_candidato.ToUpper());
                db.AddInParameter(cmd, "@ch_sexo_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_sexo_candidato);
                db.AddInParameter(cmd, "@nu_edad_candidato", DbType.Decimal, mme.me_prueba.candidato_evaluacion.nu_edad_candidato);
                db.AddInParameter(cmd, "@vc_fec_nacimiento", DbType.String, mme.me_prueba.candidato_evaluacion.vc_fec_nacimiento);
                db.AddInParameter(cmd, "@vc_lugar_nacimiento", DbType.String, mme.me_prueba.candidato_evaluacion.vc_lugar_nacimiento);
                db.AddInParameter(cmd, "@vc_estado_civil", DbType.String, mme.me_prueba.candidato_evaluacion.vc_estado_civil);
                db.AddInParameter(cmd, "@vc_direccion", DbType.String, mme.me_prueba.candidato_evaluacion.vc_direccion);
                db.AddInParameter(cmd, "@vc_nro_telefono", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nro_telefono);
                db.AddInParameter(cmd, "@vc_celular", DbType.String, mme.me_prueba.candidato_evaluacion.vc_celular);
                db.AddInParameter(cmd, "@vc_brevete", DbType.String, mme.me_prueba.candidato_evaluacion.vc_brevete);
                db.AddInParameter(cmd, "@vc_dni_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_dni_candidato);
                db.AddInParameter(cmd, "@vc_correo_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_correo_candidato);

                db.AddInParameter(cmd, "@vc_pretencion_salarial", DbType.String, mme.me_prueba.candidato_evaluacion.vc_pretencion_salarial);
                db.AddInParameter(cmd, "@vc_nombre_referencia_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato);
                db.AddInParameter(cmd, "@vc_cargo_referencia", DbType.String, mme.me_prueba.candidato_evaluacion.vc_cargo_referencia);
                db.AddInParameter(cmd, "@vc_empresa_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_empresa_candidato);
                db.AddInParameter(cmd, "@vc_telefono_referencia_candidato", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato);
                db.AddInParameter(cmd, "@vc_nombre_referencia_candidato2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato2);
                db.AddInParameter(cmd, "@vc_cargo_referencia2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_cargo_referencia2);
                db.AddInParameter(cmd, "@vc_empresa_referencia2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_empresa_referencia2);

                db.AddInParameter(cmd, "@vc_telefono_referencia_candidato2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato2);
                db.AddInParameter(cmd, "@vc_busqueda_trabajo", DbType.String, mme.me_prueba.candidato_evaluacion.vc_busqueda_trabajo);
                db.AddInParameter(cmd, "@vc_otro_proceso_seleccion", DbType.String, mme.me_prueba.candidato_evaluacion.vc_otro_proceso_seleccion);

                db.AddInParameter(cmd, "@vc_contacto", DbType.String, mme.me_prueba.candidato_evaluacion.vc_contacto);
                db.AddInParameter(cmd, "@vc_telefono_empresa1", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_empresa1);
                db.AddInParameter(cmd, "@vc_telefono_empresa2", DbType.String, mme.me_prueba.candidato_evaluacion.vc_telefono_empresa2);
                db.AddInParameter(cmd, "@vc_accidente", DbType.String, mme.me_prueba.candidato_evaluacion.vc_accidente);
                db.AddInParameter(cmd, "@vc_problema_legales", DbType.String, mme.me_prueba.candidato_evaluacion.vc_problema_legales);
                db.AddInParameter(cmd, "@vc_usr_mod", DbType.String, mme.me_prueba.candidato_evaluacion.vc_usr_mod);
                db.ExecuteNonQuery(cmd);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public int Ins_Conocimiento(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_ins_conocimiento");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_desc_conocimiento", DbType.String, mme.me_prueba.conocimiento.vc_desc_conocimiento);
                db.AddInParameter(cmd, "@vc_nivel_conocimiento", DbType.String, mme.me_prueba.conocimiento.vc_nivel_conocimiento);
                db.AddInParameter(cmd, "@vc_desc_capacidad", DbType.String, mme.me_prueba.conocimiento.vc_desc_capacidad);

                foreach (var item in mme.me_prueba.ConocimientoDetalle)
                {
                    db.SetParameterValue(cmd, "@nu_id_usuario", mme.me_prueba.candidato.nu_id_usuario);
                    db.SetParameterValue(cmd, "@vc_desc_conocimiento",item.vc_desc_conocimiento);
                    db.SetParameterValue(cmd, "@vc_nivel_conocimiento", item.vc_nivel_conocimiento);
                    db.SetParameterValue(cmd, "@vc_desc_capacidad", item.vc_desc_capacidad);

                    db.ExecuteNonQuery(cmd);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        
        public int Ins_Educacion(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_ins_educacion");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_desc_nivel_estudio", DbType.String, mme.me_prueba.educacion.vc_desc_nivel_estudio);
                db.AddInParameter(cmd, "@vc_desc_especialidad", DbType.String, mme.me_prueba.educacion.vc_desc_especialidad);
                db.AddInParameter(cmd, "@vc_centro_estudio", DbType.String, mme.me_prueba.educacion.vc_centro_estudio);
                db.AddInParameter(cmd, "@vc_anio_egreso", DbType.String, mme.me_prueba.educacion.vc_anio_egreso);
                db.AddInParameter(cmd, "@vc_titulo_obtenido", DbType.String, mme.me_prueba.educacion.vc_titulo_obtenido);
                db.AddInParameter(cmd, "@vc_ciclos_cursados", DbType.String, mme.me_prueba.educacion.vc_ciclos_cursados);

                foreach (var item in mme.me_prueba.EducacionDetalle)
                {
                    db.SetParameterValue(cmd, "@nu_id_usuario", mme.me_prueba.candidato.nu_id_usuario);
                    db.SetParameterValue(cmd, "@vc_desc_nivel_estudio", item.vc_desc_nivel_estudio);
                    db.SetParameterValue(cmd, "@vc_desc_especialidad", item.vc_desc_especialidad);
                    db.SetParameterValue(cmd, "@vc_centro_estudio", item.vc_centro_estudio);
                    db.SetParameterValue(cmd, "@vc_anio_egreso", item.vc_anio_egreso);
                    db.SetParameterValue(cmd, "@vc_titulo_obtenido", item.vc_titulo_obtenido);
                    db.SetParameterValue(cmd, "@vc_ciclos_cursados", item.vc_ciclos_cursados);

                    db.ExecuteNonQuery(cmd);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public int Ins_ExperienciaLaboral(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_ins_experiencia_laboral");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_nombre_empresa", DbType.String, mme.me_prueba.experiencia_laboral.vc_nombre_empresa);
                db.AddInParameter(cmd, "@vc_puesto", DbType.String, mme.me_prueba.experiencia_laboral.vc_puesto);
                db.AddInParameter(cmd, "@dt_fec_inicio", DbType.DateTime, mme.me_prueba.experiencia_laboral.dt_fec_inicio);
                db.AddInParameter(cmd, "@dt_fec_fin", DbType.DateTime, mme.me_prueba.experiencia_laboral.dt_fec_fin);
                db.AddInParameter(cmd, "@nu_importe_sueldo", DbType.Decimal, mme.me_prueba.experiencia_laboral.nu_importe_sueldo);
                db.AddInParameter(cmd, "@vc_motivo_retiro", DbType.String, mme.me_prueba.experiencia_laboral.vc_motivo_retiro);

                foreach (var item in mme.me_prueba.ExperienciaDetalle)
                {
                    db.SetParameterValue(cmd, "@nu_id_usuario", mme.me_prueba.candidato.nu_id_usuario);
                    db.SetParameterValue(cmd, "@vc_nombre_empresa", item.vc_nombre_empresa);
                    db.SetParameterValue(cmd, "@vc_puesto", item.vc_puesto);
                    db.SetParameterValue(cmd, "@dt_fec_inicio", (item.dt_fec_inicio == null) ? null : item.dt_fec_inicio.Value.ToShortDateString());
                    db.SetParameterValue(cmd, "@dt_fec_fin", (item.dt_fec_fin==null)?null:item.dt_fec_fin.Value.ToShortDateString());
                    db.SetParameterValue(cmd, "@nu_importe_sueldo", item.nu_importe_sueldo);
                    db.SetParameterValue(cmd, "@vc_motivo_retiro", item.vc_motivo_retiro);

                    db.ExecuteNonQuery(cmd);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public int Ins_Familiares(MME_Prueba mme)
        {
            DbCommand cmd = null;
            try
            {
                cmd = db.GetStoredProcCommand("sp_ins_familiares");
                db.AddInParameter(cmd, "@nu_id_usuario", DbType.Decimal, mme.me_prueba.candidato.nu_id_usuario);
                db.AddInParameter(cmd, "@vc_apellidos_nombres", DbType.String, mme.me_prueba.familiares.vc_apellidos_nombres);
                db.AddInParameter(cmd, "@vc_edad", DbType.String, mme.me_prueba.familiares.vc_edad);
                db.AddInParameter(cmd, "@vc_grado_academico", DbType.String, mme.me_prueba.familiares.vc_grado_academico);
                db.AddInParameter(cmd, "@vc_centro_trabajo", DbType.String, mme.me_prueba.familiares.vc_centro_trabajo);
                db.AddInParameter(cmd, "@vc_ocupacion", DbType.String, mme.me_prueba.familiares.vc_ocupacion);
                db.AddInParameter(cmd, "@vc_parentesco", DbType.String, mme.me_prueba.familiares.vc_parentesco);

                foreach (var item in mme.me_prueba.FamiliaresDetalle)
                {
                    db.SetParameterValue(cmd, "@nu_id_usuario", mme.me_prueba.candidato.nu_id_usuario);
                    db.SetParameterValue(cmd, "@vc_apellidos_nombres", item.vc_apellidos_nombres);
                    db.SetParameterValue(cmd, "@vc_edad", item.vc_edad);
                    db.SetParameterValue(cmd, "@vc_grado_academico", item.vc_grado_academico);
                    db.SetParameterValue(cmd, "@vc_centro_trabajo", item.vc_centro_trabajo);
                    db.SetParameterValue(cmd, "@vc_ocupacion", item.vc_ocupacion);
                    db.SetParameterValue(cmd, "@vc_parentesco", item.vc_parentesco);

                    db.ExecuteNonQuery(cmd);
                }

                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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

            mme.me_prueba.candidato_evaluacion.vc_nombres_candidato                 = oR["vc_nombres_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_apellidos_candidato               = oR["vc_apellidos_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_sexo_candidato                    = oR["vc_sexo_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_correo_candidato                  = oR["vc_correo_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_dni_candidato                     = oR["vc_dni_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_nro_telefono                      = oR["vc_nro_telefono"].ToText();
            mme.me_prueba.candidato_evaluacion.nu_edad_candidato                    = oR["nu_edad_candidato"].ToInt32();
            mme.me_prueba.candidato_evaluacion.vc_profesion_candidato               = oR["vc_profesion_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_ultima_experiencia_candidato      = oR["vc_ultima_experiencia_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_empresa_candidato                 = oR["vc_empresa_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.nu_sueldo_candidato                  = oR["nu_sueldo_candidato"].ToDecimal();
            mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato       = oR["vc_nombre_referencia_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato     = oR["vc_telefono_referencia_candidato"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_nombre_referencia_candidato2      = oR["vc_nombre_referencia_candidato2"].ToText();
            mme.me_prueba.candidato_evaluacion.vc_telefono_referencia_candidato2    = oR["vc_telefono_referencia_candidato2"].ToText();
            mme.me_prueba.candidato_evaluacion.nu_id_grado_instruccion              = oR["nu_id_grado_instruccion"].ToDecimal();
            mme.me_prueba.candidato_evaluacion.ch_proteccion_datos                  = oR["ch_proteccion_datos"].ToText();
            mme.me_prueba.candidato_evaluacion.ch_ficha                             = oR["ch_ficha"].ToText();
            mme.me_prueba.candidato_evaluacion.VC_CHATBOT_KEY                       = oR["VC_CHATBOT_KEY"].ToText();
            
            return mme;
        }
    }
}
