using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IPalpitesCampeoesRepositorio : IRepositorio
    {
        PalpiteCampeao ObterPorId(int palpiteCampeaoId);
        PalpiteCampeao Obter(int campeonatoId, int jogadorId);
        IQueryable<PalpiteCampeao> ObterTodos();

        void Inserir(PalpiteCampeao palpiteCampeao);
        void Atualizar(PalpiteCampeao palpiteCampeao);
    }
}
