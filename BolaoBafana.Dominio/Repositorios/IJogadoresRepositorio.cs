using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IJogadoresRepositorio : IRepositorio
    {
        bool IncluirApostas { get; set; }
        bool IncluirApostasEJogos { get; set; }
        bool IncluirApostasJogosEtapas { get; set; }

        IQueryable<Jogador> ObterTodos();
        Jogador ObterPorId(int jogadorId);
        Jogador ObterPorEmail(string email);
        Jogador ObterPorLogin(string email, string senha);

        void Inserir(Jogador jogador);
        void Atualizar(Jogador jogador);
    }
}
