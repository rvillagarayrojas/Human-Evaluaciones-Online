using Siscom.WebLib.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Elmah;
namespace EvaluacionesOnline.Areas.Seleccion.Models.Validator
{
    public class PruebasModelValidator : ValidationBase, IModelValidator<PruebasModel>
    {
        public List<KeyValuePair<string, string>> Validate(PruebasModel model)
        {
            try
            {
                var validator = new PruebasModelValidator();
                return validator.ValidationList;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }
    }
}