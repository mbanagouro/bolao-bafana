using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Colocacao
    {
        public int JogadorId { get; set; }
        public string Nickname { get; set; }
        public int Posicao { get; set; }
        public int Pontuacao { get; set; }
    }
}
