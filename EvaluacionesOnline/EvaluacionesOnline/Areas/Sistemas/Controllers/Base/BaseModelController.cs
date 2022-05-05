using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Siscom.WebLib.Validator;

namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    [SessionExpireFilter]
    public abstract class BaseModelController<T> : BaseController
    {   
        private readonly IModelValidator<T> _modelValidator = null;

        protected BaseModelController(IModelValidator<T> modelValidator)
        {
            _modelValidator = modelValidator;
        }
    }
}

