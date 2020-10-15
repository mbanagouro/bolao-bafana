using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Premiacao
    {
        public decimal PrimeiroLugar { get; set; }
        public decimal SegundoLugar { get; set; }
        public decimal TerceiroLugar { get; set; }

        public Premiacao(decimal valorArrecadado)
        {
            if (valorArrecadado != decimal.Zero)
            {
                //50%
                PrimeiroLugar = (valorArrecadado * 50) / 100;
                //20%
                SegundoLugar = (valorArrecadado * 30) / 100;
                //10%
                TerceiroLugar = (valorArrecadado * 10) / 100;
            }
        }
    }
}
