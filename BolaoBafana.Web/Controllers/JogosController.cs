using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BolaoBafana.Dados.SqlServer;
using BolaoBafana.Web.Code;
using BolaoBafana.Web.Models;

namespace BolaoBafana.Web.Controllers
{
    [BolaoAutorizado]
    public class JogosController : Controller
    {
        public ActionResult Index()
        {
            var campeonatosRepositorio = new CampeonatosRepositorio();
            campeonatosRepositorio.IncluirEtapasJogos = true;
            campeonatosRepositorio.IncluirTimes = true;

            var campeonato = campeonatosRepositorio.ObterAtual();
            if (campeonato == null)
            {
                return View("SemCampeonato");
            }

            var model = new JogosViewModel
            {
                Campeonato = campeonato,
                Apostas = new ApostasRepositorio().ObterTodasPorJogador(UserHelper.Id).ToList()
            };
            return View(model);
        }
    }
}
