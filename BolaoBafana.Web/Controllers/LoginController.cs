using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BolaoBafana.Web.Models;
using BolaoBafana.Dominio;
using BolaoBafana.Dados.SqlServer;
using BolaoBafana.Web.Code.Servicos;

namespace BolaoBafana.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var jogador = new JogadoresRepositorio().ObterPorLogin(model.Login, model.Senha);
            if (jogador != null)
            {
                ServicoDeAutenticacao.Autenticar(jogador, true);
                return Redirect(model.ReturnUrl ?? Url.Action("Index", "Jogos"));
            }
            else
            {
                ViewBag.Mensagem = "Login inválido!";
            }

            return View();
        }

        public ActionResult Logout()
        {
            ServicoDeAutenticacao.Logout();
            return RedirectToAction("Index", "Login");
        }
    }
}
