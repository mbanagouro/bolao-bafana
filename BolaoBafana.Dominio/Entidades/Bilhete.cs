using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Nbr.Core;

namespace BolaoBafana.Dominio
{
    public enum StatusCompra
    {
        [Description("Registrado")]
        Registrado,
        [Description("Cancelado")]
        Cancelado,
        [Description("Aguardando Pagamento")]
        AguardandoPagamento,
        [Description("Em Análise")]
        EmAnalise,
        [Description("Pago")]
        Pago
    }

    public class Bilhete : Entidade
    {
        public int CampeonatoId { get; set; }
        public int JogadorId { get; set; }

        public Guid Ticket { get; protected set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public DateTime ComprouEm { get; set; }
        public Campeonato Campeonato { get; set; }
        public Jogador Jogador { get; set; }        

        internal Bilhete()
        {
            Ticket = Guid.NewGuid();
            ComprouEm = DateTime.Now;
            ModificaStatus(StatusCompra.Registrado);
        }

        public Bilhete(decimal valor, Campeonato campeonato, Jogador jogador)
            :this(0, valor, campeonato, jogador)
        {
        }

        public Bilhete(int bilheteId, decimal valor, Campeonato campeonato, Jogador jogador)
            : this()
        {
            Id = bilheteId;
            Valor = valor;
            Campeonato = campeonato;
            CampeonatoId = campeonato.Id;
            Jogador = jogador;
            JogadorId = Jogador.Id;
        }

        public void ModificaStatus(StatusCompra status)
        {
            Status = status.GetDescription();
        }
    }
}
