using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio
{
    public class Indicacao : Entidade
    {
        public Guid Token { get; set; }
        public string Email { get; set; }
        public bool Cadastrou { get; set; }

        internal Indicacao()
        {
            Token = Guid.NewGuid();       
        }

        public Indicacao(string email)
            : this()
        {
            Email = email;
        }
    }
}
