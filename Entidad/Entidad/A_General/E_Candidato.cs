using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Entidad.A_General
{
    [Serializable]
    public partial class E_Candidato
    {
        public decimal? nu_id_usuario           { get; set; }
        public decimal? nu_id_persona           { get; set; }
        public decimal? nu_id_perfil            { get; set; }
        public string   vc_cod_usuario          { get; set; }
        public string   vc_password             { get; set; }
        public string   vc_nombres              { get; set; }
        public string   vc_apellidos            { get; set; }
        public string   vc_direccion_email      { get; set; }
        public string   vc_doc_identi           { get; set; }
        public string   vc_telefono             { get; set; }
        public string   vc_usr_reg              { get; set; }
        public string   vc_usr_mod              { get; set; }
        public string   ch_status               { get; set; }
        public string   vc_chatbot_key          { get; set; }
        public string   VC_IMAGEN_PERSONALIZAR  { get; set; }
        

    }
}
