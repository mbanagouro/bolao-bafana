using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Nbr.Core;

namespace BolaoBafana.Dominio
{
    public enum TipoDaEtapa
    {
        [Description("Pontos Corridos")]
        PontosCorridos,
        [Description("Mata-Mata")]
        MataMata
    }

    public class Etapa : Entidade
    {
        public string Nome { get; set; }
        public int Peso { get; set; }
        public string Tipo { get; set; }
        
        public Campeonato Campeonato { get; set; }
        public int CampeonatoId { get; set; }

        private IList<Jogo> _jogos;
        public IList<Jogo> Jogos 
        {
            get { return _jogos ?? (_jogos = new List<Jogo>()); }
            set { _jogos = value; }
        }

        public Jogo CriarJogo(Time timeDaCasa, Time timeVisitante, DateTime data)
        {
            return new Jogo(this, timeDaCasa, timeVisitante, data);
        }

        public override string ToString()
        {
            return String.Format("{0}, {1} jogo(s).", Nome, Jogos.Count());
        }

        public Etapa()
        {
        }

        public Etapa(Campeonato campeonato, string nome, int peso, TipoDaEtapa tipo)
            :this(0, campeonato, nome, peso, tipo)
        {
        }

        public Etapa(int etapaId, Campeonato campeonato, string nome, int peso, TipoDaEtapa tipo)
            : this()
        {
            Id = etapaId;
            Nome = nome;
            Peso = peso;
            Tipo = tipo.GetDescription();
            Campeonato = campeonato;
            CampeonatoId = campeonato.Id;
        }
    }
}
