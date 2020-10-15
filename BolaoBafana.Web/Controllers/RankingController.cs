using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BolaoBafana.Dominio;
using BolaoBafana.Web.Models;
using BolaoBafana.Dominio.Servicos;
using BolaoBafana.Dados.SqlServer;
using BolaoBafana.Web.Code;

namespace BolaoBafana.Web.Controllers
{
    public class RankingController : Controller
    {
        public ActionResult Index()
        {
            var colocacoes = ObterColocacoes();
            return View(colocacoes);
        }

        [ChildActionOnly]
        public ActionResult Quadro()
        {
            var valorTotalArrecadado = 
                new BilhetesRepositorio().ObterTotalDeBilhetesComprados();

            var ranking = new Ranking
            {
                Colocacao = ObterColocacoes().Take(5), //Somente os 5 primeiros
                Premiacao = new Premiacao(valorTotalArrecadado)
            };
            return PartialView(ranking);
        }

        private static List<Colocacao> ObterColocacoes()
        {
            var repositorio = new CampeonatosRepositorio();
            var servico = new CalculoDoRanking(repositorio);
            
            return servico.Resultado();
        }

        #region Outras Views

        public ActionResult Json()
        {
            if (!UserHelper.IsAutenticado)
                return Content(String.Empty);

            var colocacoes = ObterColocacoes();

            return Json(colocacoes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Xml()
        {
            if (!UserHelper.IsAutenticado)
                return Content(String.Empty);

            var colocacoes = ObterColocacoes();

            return new XmlResult(colocacoes);
        }

        #endregion
    }
}
