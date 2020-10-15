using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IIndicacoesRepositorio : IRepositorio
    {
        Indicacao ObterPorToken(Guid token);

        void Inserir(Indicacao indicacao);
        void Atualizar(Indicacao indicacao);
    }
}
