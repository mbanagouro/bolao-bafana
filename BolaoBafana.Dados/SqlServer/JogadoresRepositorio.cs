using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class JogadoresRepositorio : IJogadoresRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirApostas { get; set; }
        public bool IncluirApostasEJogos { get; set; }
        public bool IncluirApostasJogosEtapas { get; set; }

        protected IQueryable<Jogador> Jogadores
        {
            get
            {
                ObjectQuery<Jogador> jogadores = _container.Jogadores;
                if (IncluirApostas)
                    jogadores = jogadores.Include("Apostas");
                if (IncluirApostasEJogos)
                    jogadores = jogadores.Include("Apostas.Jogo");
                if (IncluirApostasJogosEtapas)
                    jogadores = jogadores.Include("Apostas.Jogo.Etapa");
                return jogadores;
            }
        }

        public JogadoresRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public JogadoresRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public IQueryable<Jogador> ObterTodos()
        {
            return Jogadores;
        }

        public Jogador ObterPorId(int jogadorId)
        {
            return Jogadores.FirstOrDefault(j => j.Id == jogadorId);
        }

        public Jogador ObterPorEmail(string email)
        {
            return Jogadores.FirstOrDefault(j => j.Email.Equals(email));
        }

        public Jogador ObterPorLogin(string email, string senha)
        {
            return Jogadores.FirstOrDefault(j => j.Email.Equals(email) && j.Senha.Equals(senha));
        }

        public void Inserir(Jogador jogador)
        {
            _container.Jogadores.AddObject(jogador);
        }

        public void Atualizar(Jogador jogador)
        {
            _container.ObjectStateManager.ChangeObjectState(jogador, EntityState.Modified);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
