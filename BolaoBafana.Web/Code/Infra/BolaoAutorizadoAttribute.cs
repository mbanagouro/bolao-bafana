using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BolaoBafana.Dominio;
using System.Web.Routing;
using BolaoBafana.Dados.SqlServer;

namespace BolaoBafana.Web.Code
{
    public class BolaoAutorizadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserHelper.IsAutenticado)
            {
                var campeonato = new CampeonatosRepositorio().ObterAtual();
                if (campeonato != null)
                {
                    if (campeonato.HabilitarBilhetes)
                    {
                        var bilhete = new BilhetesRepositorio().Obter(campeonato.Id, UserHelper.Id);
                        if (bilhete == null)
                        {
                            filterContext.Result = ObterRota("Bilhete", "Index");
                        }
                        else if (bilhete.Status != StatusCompra.Pago.ToString())
                        {
                            filterContext.Result = ObterRota("Bilhete", "Status", bilhete.Id);
                        }
                    }
                }
            }
            
            base.OnActionExecuting(filterContext);
        }

        protected static RedirectToRouteResult ObterRota(string controller, string action)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(
                new { controller = controller, action = action }
            ));
        }

        protected static RedirectToRouteResult ObterRota(string controller, string action, int bilheteId)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(
                new { controller = controller, action = action, bilheteId = bilheteId }
            ));
        }
    }
}