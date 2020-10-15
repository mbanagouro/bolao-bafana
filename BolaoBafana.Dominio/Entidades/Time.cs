using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Time : Entidade
    {
        public string Nome { get; set; }
        public string Bandeira { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
