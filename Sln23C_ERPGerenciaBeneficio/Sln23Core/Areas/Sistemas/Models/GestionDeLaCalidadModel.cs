using MultiEntidad.Sln23C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sln23Core.Areas.Sistemas.Models
{
    public class GestionDeLaCalidadModel
    {
        public MME_Mensaje_Sistema mme { get; set; }

        public GestionDeLaCalidadModel()
        {
            mme = new MME_Mensaje_Sistema();
        }
    }
}