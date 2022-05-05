using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_Seleccion
{
    [Serializable]
    public partial class E_Reporte_Conocimiento
    {
        public decimal? nu_id_candidato                 { get; set; }
        public string   vc_candidato                    { get; set; }
        public decimal? nu_edad                         { get; set; }
        public string   vc_grado_instruccion            { get; set; }
        public string   vc_profesion                    { get; set; }
        public string   vc_empresa                      { get; set; }
        public string   vc_ultima_experiencia           { get; set; }
        public string   vc_nombres_referencia           { get; set; }
        public string   vc_telefono_referencia          { get; set; }
        public string   vc_nombres_referencia2          { get; set; }
        public string   vc_telefono_referencia2         { get; set; }
        public string   vc_consultor                    { get; set; }
        public string   vc_desc_prueba                  { get; set; }
        public string   vc_desc_clasificacion_esperada  { get; set; }
        public string   vc_desc_clasificacion_obtenida  { get; set; }
        public string   vc_desc_puesto                  { get; set; }
        public decimal? nu_rango_menor_esperado         { get; set; }
        public decimal? nu_rango_mayor_esperado         { get; set; }
        public decimal? nu_rango_menor                  { get; set; }
        public decimal? nu_rango_mayor                  { get; set; }
        public decimal? nu_parametro_obtenido           { get; set; }
        public decimal? nu_parametro_obtenido_v         { get; set; }
        public decimal? nu_parametro_obtenido_n         { get; set; }
        public string   vc_recomendacion                { get; set; }
        public String   vc_desc_diagnostico             { get; set; }

        public decimal? nu_categoria_esperada           { get; set; }
        public decimal? nu_categoria_obtenida           { get; set; }

        public string   vc_patron_disc                  { get; set; }
        public string   vc_descripcion_patron           { get; set; }
        public string   vc_caracteristica               { get; set; }
        public string   vc_desc_caracteristica          { get; set; }

        public decimal? nu_valor_d                      { get; set; }
        public decimal? nu_valor_i                      { get; set; }
        public decimal? nu_valor_s                      { get; set; }
        public decimal? nu_valor_c                      { get; set; }

        public string   vc_parametro_cps                { get; set; }
        public decimal? nu_marcadas                     { get; set; }
        public decimal? nu_valor_cps                    { get; set; }

        public string   vc_desc_perfil                  { get; set; }
        public string   vc_letra_parametro              { get; set; }

        public String   vc_area_evaluada                { get; set; }
        public String   vc_positivo                     { get; set; }
        public String   vc_negativo                     { get; set; }
    }
}
