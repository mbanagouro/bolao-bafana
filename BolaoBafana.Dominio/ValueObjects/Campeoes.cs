using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Campeoes
    {
        public string Campeao { get; set; }
        public string ViceCampeao { get; set; }
        public string TerceiroCampeao { get; set; }
        public string QuartoCampeao { get; set; }

        public Campeoes()
        {
            Campeao = String.Empty;
            ViceCampeao = String.Empty;
            TerceiroCampeao = String.Empty;
            QuartoCampeao = String.Empty;
        }
    }
}
