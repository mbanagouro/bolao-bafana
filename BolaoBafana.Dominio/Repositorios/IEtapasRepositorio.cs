using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IEtapasRepositorio : IRepositorio
    {
        bool IncluirCampeonato { get; set; }
        bool IncluirJogos { get; set; }
        bool IncluirJogosTimeDaCasa { get; set; }
        bool IncluirJogosTimeVisitante { get; set; }

        Etapa ObterPorId(int etapaId);
        IQueryable<Etapa> ObterTodosPorCampeonato(int campeonatoId);

        void Inserir(Etapa etapa);
        void Atualizar(Etapa etapa);
    }
}
