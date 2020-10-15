using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;

namespace BolaoBafana.Web.Models
{
    public class JogosViewModel
    {
        public Campeonato Campeonato { get; set; }

        public IList<Aposta> Apostas { get; set; }
    }
}
