using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using System.Data;

namespace BolaoBafana.Dados.SqlServer
{
    public class PalpitesCampeoesRepositorio : IPalpitesCampeoesRepositorio
    {
        private BolaoBafanaContainer _container;

        public PalpitesCampeoesRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public PalpiteCampeao ObterPorId(int palpiteCampeaoId)
        {
            return _container.PalpitesCampeoes.FirstOrDefault(x => x.Id == palpiteCampeaoId);
        }

        public PalpiteCampeao Obter(int campeonatoId, int jogadorId)
        {
            return _container.PalpitesCampeoes.FirstOrDefault(x => x.CampeonatoId == campeonatoId && x.JogadorId == jogadorId);
        }

        public IQueryable<PalpiteCampeao> ObterTodos()
        {
            return _container.PalpitesCampeoes;
        }

        public void Inserir(PalpiteCampeao palpiteCampeao)
        {
            _container.PalpitesCampeoes.AddObject(palpiteCampeao);
        }

        public void Atualizar(PalpiteCampeao palpiteCampeao)
        {
            _container.ObjectStateManager.ChangeObjectState(palpiteCampeao, EntityState.Modified);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
