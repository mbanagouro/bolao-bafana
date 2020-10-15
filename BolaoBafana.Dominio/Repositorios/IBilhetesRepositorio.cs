using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IBilhetesRepositorio : IRepositorio
    {
        bool IncluirJogador { get; set; }

        Bilhete ObterPorTicket(Guid ticket);
        Bilhete ObterPorId(int bilheteId);
        Bilhete ObterPorPorIdEJogador(int bilheteId, int jogadorId);
        Bilhete Obter(int campeonatoId, int jogadorId);
        IQueryable<Bilhete> ObterTodosPorCampeonato(int campeonatoId);
        decimal ObterTotalDeBilhetesComprados();

        void Inserir(Bilhete bilhete);
        void Atualizar(Bilhete bilhete);
        void Excluir(Bilhete bilhete);
    }
}
