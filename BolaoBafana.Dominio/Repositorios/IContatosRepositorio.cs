using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IContatosRepositorio : IRepositorio
    {
        IQueryable<Contato> ObterTodos();

        void Inserir(Contato contato);
    }
}
