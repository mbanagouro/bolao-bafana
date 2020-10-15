using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Placar
    {
        public int? TimeDaCasa { get; set; }
        public bool? TimeDaCasaPenalti { get; set; }
        public int? TimeVisitante { get; set; }
        public bool? TimeVisitantePenalti { get; set; }

        public bool Finalizado
        {
            get { return (TimeDaCasa.HasValue && TimeVisitante.HasValue); }
        }

        public bool Empatou
        {
            get { return (Finalizado && (TimeDaCasa.Value == TimeVisitante.Value)); }
        }

        public bool EncerrouNosPenaltis
        {
            get { return (TimeDaCasaPenalti.HasValue || TimeVisitantePenalti.HasValue); }
        }

        public bool TimeDaCasaVenceu
        {
            get { return (Finalizado && (TimeDaCasa.Value > TimeVisitante.Value)); }
        }

        public bool TimeDaCasaVenceuNosPenaltis
        {
            get { return (Finalizado && (TimeDaCasaPenalti.HasValue && TimeDaCasaPenalti.Value)); }
        }

        public bool TimeVisitanteVenceu
        {
            get { return (Finalizado && (TimeVisitante.Value > TimeDaCasa.Value)); }
        }

        public bool TimeVisitanteVenceuNosPenaltis
        {
            get { return (Finalizado && (TimeVisitantePenalti.HasValue && TimeVisitantePenalti.Value)); }
        }
    }
}
