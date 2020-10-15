using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;

namespace BolaoBafana.Dados.SqlServer
{
    public class ContatosRepositorio : IContatosRepositorio
    {
        private BolaoBafanaContainer _container;

        public ContatosRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public ContatosRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public IQueryable<Contato> ObterTodos()
        {
            return _container.Contatos;
        }

        public void Inserir(Contato contato)
        {
            _container.Contatos.AddObject(contato);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
