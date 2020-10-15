
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data;
using System.Data.Objects;

namespace BolaoBafana.Dados.SqlServer
{
    public class ApostasRepositorio : IApostasRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirJogador { get; set; }
        public bool IncluirJogo { get; set; }
        public bool IncluirJogoTimes { get; set; }
        public bool IncluirJogoEtapa { get; set; }

        protected IQueryable<Aposta> Apostas
        {
            get
            {
                ObjectQuery<Aposta> apostas = _container.Apostas;
                if (IncluirJogador)
                    apostas = apostas.Include("Jogador");
                if (IncluirJogo)
                    apostas = apostas.Include("Jogo");
                if (IncluirJogoEtapa)
                    apostas = apostas.Include("Jogo.Etapa");
                if (IncluirJogoTimes)
                {
                    apostas = apostas.Include("Jogo.TimeDaCasa");
                    apostas = apostas.Include("Jogo.TimeVisitante");
                }
                return apostas;
            }
        }

        public ApostasRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public ApostasRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public Aposta ObterPorId(int apostaId)
        {
            return Apostas.FirstOrDefault(a => a.Id == apostaId);
        }

        public IQueryable<Aposta> ObterTodas()
        {
            return Apostas;
        }

        public IQueryable<Aposta> ObterTodasPorJogo(int jogoId)
        {
            return Apostas.Where(a => a.JogoId == jogoId);
        }

        public IQueryable<Aposta> ObterTodasPorJogador(int jogadorId)
        {
            return Apostas.Where(a => a.JogadorId == jogadorId);
        }

        public void Inserir(Aposta aposta)
        {
            _container.Apostas.AddObject(aposta);
        }

        public void Atualizar(Aposta aposta)
        {
            _container.ObjectStateManager.ChangeObjectState(aposta, EntityState.Modified);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
