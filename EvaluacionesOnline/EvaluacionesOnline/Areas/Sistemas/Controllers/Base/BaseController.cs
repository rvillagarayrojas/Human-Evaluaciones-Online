using System.Web.Mvc;
using Siscom.WebLib.MvcShared;
using EvaluacionesOnline.Areas.Sistemas.Models;
using Elmah;

namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    public abstract class BaseController : Controller
    {
        public SesionModel mme_session
        {
            get
            {
                try
                {
                    if (Session[SesionModel.SessionName] == null)
                        Session[SesionModel.SessionName] = new SesionModel();
                    return (SesionModel)Session[SesionModel.SessionName];
                }
                catch (System.Exception ex)
                {
                    ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                    throw;
                }

            }
            set
            {
                try
                {
                    Session[SesionModel.SessionName] = value;
                }
                catch (System.Exception ex)
                {
                    ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                    throw;
                }
                
            }
        }
    }
}
