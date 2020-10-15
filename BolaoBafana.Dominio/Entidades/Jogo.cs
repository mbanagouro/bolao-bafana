using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Jogo : Entidade
    {
        public int EtapaId { get; set; }
        
        public DateTime Data { get; set; }
        public Etapa Etapa { get; set; }
        public Time TimeDaCasa { get; set; }
        public Time TimeVisitante { get; set; }
        public Placar Resultado { get; set; }
        public string EmbedVideo { get; set; }

        private IList<Aposta> _apostas;
        public IList<Aposta> Apostas
        {
            get { return _apostas ?? (_apostas = new List<Aposta>()); }
            set { _apostas = value; }
        }

        public Aposta CriarAposta(Jogador jogador)
        {
            return new Aposta(this, jogador);
        }

        public double DataEmSegundos
        {
            get { return Math.Round(Data.Subtract(DateTime.Now).TotalSeconds, 0); }
        }

        public override string ToString()
        {
            if (Resultado.Finalizado)
            {
                if (Resultado.EncerrouNosPenaltis)
	            {
                    string vencedor = String.Empty;
                    if (Resultado.TimeDaCasaVenceuNosPenaltis)
                    {
                        vencedor = TimeDaCasa.Nome;
                    }
                    else if (Resultado.TimeVisitanteVenceuNosPenaltis)
                    {
                        vencedor = TimeVisitante.Nome;
                    }

                    if (String.IsNullOrWhiteSpace(vencedor))
                    {
                        return String.Format("{0} {1} x {2} {3}",
                                         TimeDaCasa.Nome, Resultado.TimeDaCasa.Value,
                                         Resultado.TimeVisitante.Value, TimeVisitante.Nome);
                    }

                    return String.Format("{0} {1} x {2} {3}. {4} ganhou nos pênaltis",
                                         TimeDaCasa.Nome, Resultado.TimeDaCasa.Value,
                                         Resultado.TimeVisitante.Value, TimeVisitante.Nome,
                                         vencedor);                    
	            }
                
                return String.Format("{0} {1} x {2} {3}",
                                     TimeDaCasa.Nome, Resultado.TimeDaCasa.Value,
                                     Resultado.TimeVisitante.Value, TimeVisitante.Nome);
            }
            
            return String.Format("{0} x {1}", TimeDaCasa.Nome, TimeVisitante.Nome);
        }

        public Jogo()
        {
            Resultado = new Placar();
            EmbedVideo = String.Empty;
        }

        public Jogo(Etapa etapa, Time timeDaCasa, Time timeVisitante, DateTime data)
            :this(0, etapa, timeDaCasa, timeVisitante, data)
        {
        }

        public Jogo(int jogoId, Etapa etapa, Time timeDaCasa, Time timeVisitante, DateTime data)
            : this()
        {
            Id = jogoId;
            Etapa = etapa;
            EtapaId = etapa.Id;
            TimeDaCasa = timeDaCasa;
            TimeVisitante = timeVisitante;
            Data = data;
        }
    }
}
