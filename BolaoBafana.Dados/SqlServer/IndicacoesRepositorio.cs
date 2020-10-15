using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data.Objects;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class IndicacoesRepositorio : IIndicacoesRepositorio
    {
        private BolaoBafanaContainer _container;

        public IndicacoesRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public IndicacoesRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public Indicacao ObterPorToken(Guid token)
        {
            return _container.Indicacoes.FirstOrDefault(j => j.Token.Equals(token));
        }

        public void Inserir(Indicacao indicacao)
        {
            _container.Indicacoes.AddObject(indicacao);
        }

        public void Atualizar(Indicacao indicacao)
        {
            _container.ObjectStateManager.ChangeObjectState(indicacao, EntityState.Modified);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
