using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BolaoBafana.Dominio;

namespace BolaoBafana.Web.Code.Servicos
{
    public static class ServicoDeAutenticacao
    {
        public static void Autenticar(Jogador jogador, bool manterConectado = false)
        {
            var chave = String.Join(";", new string[] { jogador.Id.ToString(), jogador.NomeCompleto, jogador.Email });
            FormsAuthentication.SetAuthCookie(chave, manterConectado);
        }

        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}