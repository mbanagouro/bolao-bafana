using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class JogosRepositorio : IJogosRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirEtapa { get; set; }
        public bool IncluirApostas { get; set; }
        public bool IncluirApostasJogador { get; set; }
        public bool IncluirTimes { get; set; }

        protected IQueryable<Jogo> Jogos
        {
            get
            {
                ObjectQuery<Jogo> jogos = _container.Jogos;
                if (IncluirEtapa)
                    jogos = jogos.Include("Etapa");
                if (IncluirApostas)
                    jogos = jogos.Include("Apostas");
                if (IncluirApostasJogador)
                    jogos = jogos.Include("Apostas.Jogador");
                if (IncluirTimes)
                { 
                    jogos = jogos.Include("TimeDaCasa");
                    jogos = jogos.Include("TimeVisitante");
                }
                return jogos;
            }
        }

        public JogosRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public JogosRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public Jogo ObterPorId(int jogoId)
        {
            return Jogos.FirstOrDefault(j => j.Id == jogoId);
        }

        public void Inserir(Jogo jogo)
        {
            _container.Jogos.AddObject(jogo);
        }

        public void Atualizar(Jogo jogo)
        {
            _container.ObjectStateManager.ChangeObjectState(jogo, EntityState.Modified);
        }

        public void Excluir(Jogo jogo)
        {
            _container.DeleteObject(jogo);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
