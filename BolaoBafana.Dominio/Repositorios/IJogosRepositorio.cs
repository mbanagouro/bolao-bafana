using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IJogosRepositorio : IRepositorio
    {
        bool IncluirEtapa { get; set; }
        bool IncluirApostas { get; set; }
        bool IncluirApostasJogador { get; set; }
        bool IncluirTimes { get; set; }

        Jogo ObterPorId(int jogoId);

        void Inserir(Jogo jogo);
        void Atualizar(Jogo jogo);
        void Excluir(Jogo jogo);
    }
}
