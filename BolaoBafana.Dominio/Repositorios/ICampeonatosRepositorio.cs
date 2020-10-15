using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface ICampeonatosRepositorio : IRepositorio
    {
        bool IncluirEtapas { get; set; }
        bool IncluirEtapasJogos { get; set; }
        bool IncluirEtapasJogosApostas { get; set; }
        bool IncluirEtapasJogosApostasJogador { get; set; }
        bool IncluirTimes { get; set; }

        Campeonato ObterPorId(int campeonatoId);
        Campeonato ObterAtual();
        IQueryable<Campeonato> ObterTodos();
                
        void Inserir(Campeonato campeonato);
        void Atualizar(Campeonato campeonato);
        void Excluir(Campeonato campeonato);
    }
}
