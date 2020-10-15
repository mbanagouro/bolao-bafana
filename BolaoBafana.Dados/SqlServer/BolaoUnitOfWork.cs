using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;

namespace BolaoBafana.Dados.SqlServer
{
    public class BolaoUnitOfWork : IUnitOfWork
    {
        private BolaoBafanaContainer _container;
        internal BolaoBafanaContainer Container
        {
            get { return _container ?? (_container = new BolaoBafanaContainer()); }
        }

        private ICampeonatosRepositorio _campeonatosRepositorio;
        public ICampeonatosRepositorio CampeonatosRepositorio
        {
            get { return _campeonatosRepositorio ?? (_campeonatosRepositorio = new CampeonatosRepositorio(Container)); }
        }

        private IEtapasRepositorio _etapasRepositorio;
        public IEtapasRepositorio EtapasRepositorio
        {
            get { return _etapasRepositorio ?? (_etapasRepositorio = new EtapasRepositorio(Container)); }
        }

        private IJogosRepositorio _jogosRepositorio;
        public IJogosRepositorio JogosRepositorio
        {
            get { return _jogosRepositorio ?? (_jogosRepositorio = new JogosRepositorio(Container)); }
        }

        private ITimesRepositorio _timesRepositorio;
        public ITimesRepositorio TimesRepositorio
        {
            get { return _timesRepositorio ?? (_timesRepositorio = new TimesRepositorio(Container)); }
        }

        private IApostasRepositorio _apostasRepositorio;
        public IApostasRepositorio ApostasRepositorio
        {
            get { return _apostasRepositorio ?? (_apostasRepositorio = new ApostasRepositorio(Container)); }
        }

        private IJogadoresRepositorio _jogadoresRepositorio;
        public IJogadoresRepositorio JogadoresRepositorio
        {
            get { return _jogadoresRepositorio ?? (_jogadoresRepositorio = new JogadoresRepositorio(Container)); }
        }

        private IPalpitesCampeoesRepositorio _palpitesCampeoesRepositorio;
        public IPalpitesCampeoesRepositorio PalpitesCampeoesRepositorio
        {
            get { return _palpitesCampeoesRepositorio ?? (_palpitesCampeoesRepositorio = new PalpitesCampeoesRepositorio(Container)); }
        }
        
        private IBilhetesRepositorio _bilhetesRepositorio;
        public IBilhetesRepositorio BilhetesRepositorio
        {
            get { return _bilhetesRepositorio ?? (_bilhetesRepositorio = new BilhetesRepositorio(Container)); }
        }

        private IIndicacoesRepositorio _indicacoesRepositorio;
        public IIndicacoesRepositorio IndicacoesRepositorio
        {
            get { return _indicacoesRepositorio ?? (_indicacoesRepositorio = new IndicacoesRepositorio(Container)); }
        }

        public void Commit()
        {
            Container.SaveChanges();
        }
    }
}
