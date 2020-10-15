using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IApostasRepositorio : IRepositorio
    {
        bool IncluirJogador { get; set; }
        bool IncluirJogo { get; set; }
        bool IncluirJogoTimes { get; set; }
        bool IncluirJogoEtapa { get; set; }

        Aposta ObterPorId(int apostaId);
        IQueryable<Aposta> ObterTodas();
        IQueryable<Aposta> ObterTodasPorJogo(int jogoId);
        IQueryable<Aposta> ObterTodasPorJogador(int jogadorId);

        void Inserir(Aposta aposta);
        void Atualizar(Aposta aposta);
    }
}
