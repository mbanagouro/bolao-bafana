using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Jogador : Entidade
    {
        public string NomeCompleto { get; set; }
        public string Nickname { get; set; }
        public DateTime CadastradoEm { get; set; }

        //Login
        public string Email { get; set; }
        public string Senha { get; set; }

        private IList<Aposta> _apostas;
        public IList<Aposta> Apostas
        {
            get { return _apostas ?? (_apostas = new List<Aposta>()); }
            set { _apostas = value; }
        }

        private IList<PalpiteCampeao> _palitesCampeoes;
        public IList<PalpiteCampeao> PalpitesCampeoes
        {
            get { return _palitesCampeoes ?? (_palitesCampeoes = new List<PalpiteCampeao>()); }
            set { _palitesCampeoes = value; }
        }

        internal Jogador()
        {
            CadastradoEm = DateTime.Now;
        }

        public Jogador(string nomeCompleto, string nickName, string email, string senha)
            : this(0, nomeCompleto, nickName, email, senha)
        {
        }

        public Jogador(int jogadorId, string nomeCompleto, string nickName, string email, string senha)
            :this()
        {
            if (String.IsNullOrWhiteSpace(nomeCompleto))
                throw new ArgumentNullException("nomeCompleto");
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException("email");
            if (String.IsNullOrWhiteSpace(nickName))
                throw new ArgumentNullException("nickName");
            if (String.IsNullOrWhiteSpace(senha))
                throw new ArgumentNullException("senha");

            Id = jogadorId;
            NomeCompleto = nomeCompleto;
            Nickname = nickName;
            Email = email;
            Senha = senha;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", NomeCompleto, Nickname);
        }
    }
}
