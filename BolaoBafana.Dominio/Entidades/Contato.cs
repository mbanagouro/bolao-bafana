using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Contato : Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public Contato()
        {
            Data = DateTime.Now;
        }
    }
}
