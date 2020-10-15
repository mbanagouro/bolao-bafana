using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Campeonato : Entidade
    {
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public Campeoes Campeoes { get; set; }
        public bool HabilitarBilhetes { get; set; }

        private IList<Etapa> _etapas;
        public IList<Etapa> Etapas
        {
            get { return _etapas ?? (_etapas = new List<Etapa>()); }
            set { _etapas = value; }
        }

        private IList<PalpiteCampeao> _palitesCampeoes;
        public IList<PalpiteCampeao> PalpitesCampeoes
        {
            get { return _palitesCampeoes ?? (_palitesCampeoes = new List<PalpiteCampeao>()); }
            set { _palitesCampeoes = value; }
        }

        public Etapa CriarEtapa(string nome, int peso, TipoDaEtapa tipo)
        {
            return new Etapa(this, nome, peso, tipo);
        }

        public override string ToString()
        {
            return String.Format("{0} ({1:dd/MM/yyyy} à {2:dd/MM/yyyy})", Nome, Inicio, Termino);
        }

        internal Campeonato()
        {
            Campeoes = new Campeoes();
        }

        public Campeonato(string nome, DateTime inicio, DateTime termino)
            :this(0, nome, inicio, termino)
        {
        }

        public Campeonato(int cameponatoId, string nome, DateTime inicio, DateTime termino)
            : this()
        {
            if (String.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException("nome");
            if (inicio > termino)
                throw new ArgumentException("A data de início não pode ser maior que a data do término.");
            if (DateTime.Now > termino)
                throw new ArgumentException("A data de hoje não pode ser maior que a data do término.");

            Id = cameponatoId;
            Nome = nome;
            Inicio = inicio;
            Termino = termino;
        }

        public PalpiteCampeao CriarPalpiteCampeao(Jogador jogador)
        {
            return new PalpiteCampeao(this, jogador);
        }
    }
}
