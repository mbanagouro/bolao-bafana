using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface ITimesRepositorio : IRepositorio
    {
        Time ObterPorId(int timeId);
        IQueryable<Time> ObterTodos();

        void Inserir(Time campeonato);
        void Excluir(int id);
    }
}
