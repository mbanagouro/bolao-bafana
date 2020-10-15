using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class EtapasRepositorio : IEtapasRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirCampeonato { get; set; }
        public bool IncluirJogos { get; set; }
        public bool IncluirJogosTimeDaCasa { get; set; }
        public bool IncluirJogosTimeVisitante { get; set; }

        protected IQueryable<Etapa> Etapas
        {
            get
            {
                ObjectQuery<Etapa> etapas = _container.Etapas;
                if (IncluirCampeonato)
                    etapas = etapas.Include("Campeonato");
                if (IncluirJogos)
                    etapas = etapas.Include("Jogos");
                if (IncluirJogosTimeDaCasa)
                    etapas = etapas.Include("Jogos.TimeDaCasa");
                if (IncluirJogosTimeVisitante)
                    etapas = etapas.Include("Jogos.TimeVisitante");
                return etapas;
            }
        }

        public EtapasRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public void Commit()
        {
            _container.SaveChanges();
        }

        public Etapa ObterPorId(int etapaId)
        {
            return Etapas.FirstOrDefault(c => c.Id == etapaId);
        }

        public IQueryable<Etapa> ObterTodosPorCampeonato(int campeonatoId)
        {
            return Etapas.Where(e => e.CampeonatoId == campeonatoId);
        }

        public void Inserir(Etapa etapa)
        {
            _container.Etapas.AddObject(etapa);
        }

        public void Atualizar(Etapa etapa)
        {
            _container.ObjectStateManager.ChangeObjectState(etapa, EntityState.Modified);
        }
    }
}
