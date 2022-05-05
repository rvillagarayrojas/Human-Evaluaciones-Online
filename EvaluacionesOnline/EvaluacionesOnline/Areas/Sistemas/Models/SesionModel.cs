using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiEntidad.A_Sistemas;

namespace EvaluacionesOnline.Areas.Sistemas.Models
{
    public class SesionModel
    {
        public const string SessionName = "SesionModel";

        protected MME_Sesion mme_sesion;

        public SesionModel()
        {
            mme_sesion = new MME_Sesion();
        }

        public MME_Sesion MME_Sesion
        {
            get { return mme_sesion; }
            set { mme_sesion = value; }
        }
    }
}