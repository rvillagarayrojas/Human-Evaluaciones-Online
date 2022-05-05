using EvaluacionesOnline.Areas.Sistemas.Models;
using System.Web;
using System.Web.Mvc;
using Elmah;

namespace EvaluacionesOnline.Areas.Seleccion.Controllers
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                var ctx = HttpContext.Current;

                if (ctx.Session[SesionModel.SessionName] == null
                    && (filterContext.ActionDescriptor).ActionName != "AC_Acceder")
                {
                    ctx.Response.Redirect("/");
                }

                base.OnActionExecuting(filterContext);
            }
            catch (System.Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex); //ELMAH Signaling
                throw;
            }

        }
    } 
}
