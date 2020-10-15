using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Ranking
    {
        public IEnumerable<Colocacao> Colocacao { get; set; }
        
        public Premiacao Premiacao { get; set; }
    }
}
