using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BolaoBafana.Dominio;
using Nbr.Core;
using System.Data.Objects;

namespace BolaoBafana.Dados.SqlServer
{
    public class BilhetesRepositorio : IBilhetesRepositorio
    {
        private BolaoBafanaContainer _container;

        public bool IncluirJogador { get; set; }

        protected IQueryable<Bilhete> Bilhetes
        {
            get
            {
                ObjectQuery<Bilhete> bilhetes = _container.Bilhetes;
                if (IncluirJogador)
                    bilhetes = bilhetes.Include("Jogador");
                return bilhetes;
            }
        }

        public BilhetesRepositorio()
            : this(new BolaoBafanaContainer())
        {
        }

        public BilhetesRepositorio(BolaoBafanaContainer container)
        {
            _container = container;
        }

        public Bilhete ObterPorTicket(Guid ticket)
        {
            return Bilhetes.FirstOrDefault(b => b.Ticket.Equals(ticket));
        }

        public Bilhete ObterPorId(int bilheteId)
        {
            return Bilhetes.FirstOrDefault(b => b.Id == bilheteId);
        }

        public IQueryable<Bilhete> ObterTodosPorCampeonato(int campeonatoId)
        {
            return Bilhetes.Where(b => b.CampeonatoId == campeonatoId);
        }

        public Bilhete ObterPorPorIdEJogador(int bilheteId, int jogadorId)
        {
            return Bilhetes.FirstOrDefault(b => b.Id == bilheteId && b.JogadorId == jogadorId);
        }

        public Bilhete Obter(int campeonatoId, int jogadorId)
        {
            //var cancelado = StatusCompra.Cancelado.GetDescription();
            //return _container.Bilhetes.FirstOrDefault(b => b.CampeonatoId == campeonatoId && b.JogadorId == jogadorId && !b.Status.Equals(cancelado));
            return Bilhetes.FirstOrDefault(b => b.CampeonatoId == campeonatoId && b.JogadorId == jogadorId);
        }

        public decimal ObterTotalDeBilhetesComprados()
        {
            var statusPago = StatusCompra.Pago.GetDescription();
            if (Bilhetes.Where(b => b.Status.Equals(statusPago)).Count() > 0)
            {
                return Bilhetes.Where(b => b.Status.Equals(statusPago)).Sum(b => b.Valor);    
            }
            return decimal.Zero;
        }

        public void Inserir(Bilhete bilhete)
        {
            _container.Bilhetes.AddObject(bilhete);
        }

        public void Atualizar(Bilhete bilhete)
        {
            _container.ObjectStateManager.ChangeObjectState(bilhete, EntityState.Modified);
        }

        public void Excluir(Bilhete bilhete)
        {
            _container.Bilhetes.DeleteObject(bilhete);
        }

        public void Commit()
        {
            _container.SaveChanges();
        }
    }
}
