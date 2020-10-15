using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public interface IUnitOfWork
    {
        ICampeonatosRepositorio CampeonatosRepositorio { get; }
        IEtapasRepositorio EtapasRepositorio { get; }
        IJogosRepositorio JogosRepositorio { get; }
        ITimesRepositorio TimesRepositorio { get; }
        IApostasRepositorio ApostasRepositorio { get; }
        IJogadoresRepositorio JogadoresRepositorio { get; }
        IPalpitesCampeoesRepositorio PalpitesCampeoesRepositorio { get; }
        IBilhetesRepositorio BilhetesRepositorio { get; }
        IIndicacoesRepositorio IndicacoesRepositorio { get; }

        void Commit();
    }
}
