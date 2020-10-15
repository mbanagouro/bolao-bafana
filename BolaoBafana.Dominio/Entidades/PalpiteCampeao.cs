using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class PalpiteCampeao : Entidade
    {
        public int JogadorId { get; set; }
        public int CampeonatoId { get; set; }
        
        public DateTime Data { get; protected set; }
        public Campeoes Palpite { get; set; }
        public Campeonato Campeonato { get; set; }
        public Jogador Jogador { get; set; }        

        public PalpiteCampeao()
        {
            Data = DateTime.Now;
            Palpite = new Campeoes();
        }

        public PalpiteCampeao(Campeonato campeonato, Jogador jogador)
            :this()
        {
            Campeonato = campeonato;
            CampeonatoId = campeonato.Id;
            Jogador = jogador;
            JogadorId = jogador.Id;
        }

        public void Palpitar(Campeoes campeoes)
        {
            Palpite = campeoes ?? new Campeoes();
            Data = DateTime.Now;
        }
    }
}
