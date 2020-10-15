using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;

namespace BolaoBafana.Dados.SqlServer
{
    public class TimesRepositorio : ITimesRepositorio
    {
        private BolaoBafanaContainer _container;

        public TimesRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public void Commit()
        {
            _container.SaveChanges();
        }

        public Time ObterPorId(int campeonatoId)
        {
            return _container.Times.FirstOrDefault(c => c.Id == campeonatoId);
        }

        public IQueryable<Time> ObterTodos()
        {
            return _container.Times;
        }

        public void Inserir(Time time)
        {
            _container.Times.AddObject(time);
        }

        public void Excluir(int id)
        {
            var time = ObterPorId(id);
            _container.Times.DeleteObject(time);
        }
    }
}
