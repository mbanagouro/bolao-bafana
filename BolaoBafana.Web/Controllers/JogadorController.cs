using System;
using System.Linq;
using System.Web.Mvc;
using BolaoBafana.Dados.SqlServer;
using BolaoBafana.Dominio;
using BolaoBafana.Dominio.Servicos;
using BolaoBafana.Web.Code;

namespace BolaoBafana.Web.Controllers
{
    public class JogadorController : Controller
    {
        [ChildActionOnly]
        public ActionResult Status()
        {
            if (!UserHelper.IsAutenticado)
                return Content(String.Empty);

            var colocacao = ObterColocacao();

            return PartialView(colocacao);
        }

        private static Colocacao ObterColocacao()
        {
            var repositorio = new CampeonatosRepositorio();
            var servico = new CalculoDoRanking(repositorio);
            return servico.Resultado().FirstOrDefault(x => x.JogadorId == UserHelper.Id);
        }
    }
}
