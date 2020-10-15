using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BolaoBafana.Dominio;
using BolaoBafana.Web.Code;
using BolaoBafana.Web.Models;
using BolaoBafana.Dados.SqlServer;

namespace BolaoBafana.Web.Controllers
{
    public class BilheteController : Controller
    {
        public ActionResult Index()
        {
            var campeonato = new CampeonatosRepositorio().ObterAtual();

            if (campeonato == null)
                return RedirectToAction("Index", "Home");

            return View(campeonato);
        }

        public ActionResult Status(int bilheteId)
        {
            var bilhete = new BilhetesRepositorio().ObterPorPorIdEJogador(bilheteId, UserHelper.Id);
            return View(bilhete);
        }
    }
}
