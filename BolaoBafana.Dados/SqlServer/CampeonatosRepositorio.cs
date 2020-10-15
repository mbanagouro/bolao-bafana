using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class CampeonatosRepositorio : ICampeonatosRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirEtapas { get; set; }
        public bool IncluirEtapasJogos { get; set; }
        public bool IncluirEtapasJogosApostas { get; set; }
        public bool IncluirEtapasJogosApostasJogador { get; set; }
        public bool IncluirTimes { get; set; }

        protected IQueryable<Campeonato> Campeonatos
        {
            get
            {
                ObjectQuery<Campeonato> campeonatos = _container.Campeonatos;
                if (IncluirEtapas)
                    campeonatos = campeonatos.Include("Etapas");
                if (IncluirEtapasJogos)
                    campeonatos = campeonatos.Include("Etapas.Jogos");
                if (IncluirEtapasJogosApostas)
                    campeonatos = campeonatos.Include("Etapas.Jogos.Apostas");
                if (IncluirEtapasJogosApostasJogador)
                    campeonatos = campeonatos.Include("Etapas.Jogos.Apostas.Jogador");
                if (IncluirTimes)
                {
                    campeonatos = campeonatos.Include("Etapas.Jogos.TimeDaCasa");
                    campeonatos = campeonatos.Include("Etapas.Jogos.TimeVisitante");
                }
                return campeonatos;
            }
        }

        public CampeonatosRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public CampeonatosRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public void Commit()
        {
            _container.SaveChanges();
        }

        public Campeonato ObterPorId(int campeonatoId)
        {
            return Campeonatos.FirstOrDefault(c => c.Id == campeonatoId);
        }

        public Campeonato ObterAtual()
        {
            return Campeonatos.FirstOrDefault(c => c.Termino >= DateTime.Now && c.Inicio <= DateTime.Now);
        }

        public IQueryable<Campeonato> ObterTodos()
        {
            return Campeonatos;
        }

        public void Inserir(Campeonato campeonato)
        {
            _container.Campeonatos.AddObject(campeonato);
        }

        public void Atualizar(Campeonato campeonato)
        {
            _container.ObjectStateManager.ChangeObjectState(campeonato, EntityState.Modified);
        }

        public void Excluir(Campeonato campeonato)
        {
            _container.Campeonatos.DeleteObject(campeonato);
        }
    }
}
