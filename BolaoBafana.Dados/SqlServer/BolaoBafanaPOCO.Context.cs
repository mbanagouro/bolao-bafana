//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;
using BolaoBafana.Dominio;

namespace BolaoBafana.Dados.SqlServer
{
    public partial class BolaoBafanaContainer : ObjectContext
    {
        public const string ConnectionString = "name=BolaoBafanaContainer";
        public const string ContainerName = "BolaoBafanaContainer";
    
        #region Constructors
    
        public BolaoBafanaContainer()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public BolaoBafanaContainer(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public BolaoBafanaContainer(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Campeonato> Campeonatos
        {
            get { return _campeonatos  ?? (_campeonatos = CreateObjectSet<Campeonato>("Campeonatos")); }
        }
        private ObjectSet<Campeonato> _campeonatos;
    
        public ObjectSet<Etapa> Etapas
        {
            get { return _etapas  ?? (_etapas = CreateObjectSet<Etapa>("Etapas")); }
        }
        private ObjectSet<Etapa> _etapas;
    
        public ObjectSet<Jogo> Jogos
        {
            get { return _jogos  ?? (_jogos = CreateObjectSet<Jogo>("Jogos")); }
        }
        private ObjectSet<Jogo> _jogos;
    
        public ObjectSet<Aposta> Apostas
        {
            get { return _apostas  ?? (_apostas = CreateObjectSet<Aposta>("Apostas")); }
        }
        private ObjectSet<Aposta> _apostas;
    
        public ObjectSet<Jogador> Jogadores
        {
            get { return _jogadores  ?? (_jogadores = CreateObjectSet<Jogador>("Jogadores")); }
        }
        private ObjectSet<Jogador> _jogadores;
    
        public ObjectSet<Time> Times
        {
            get { return _times  ?? (_times = CreateObjectSet<Time>("Times")); }
        }
        private ObjectSet<Time> _times;
    
        public ObjectSet<Bilhete> Bilhetes
        {
            get { return _bilhetes  ?? (_bilhetes = CreateObjectSet<Bilhete>("Bilhetes")); }
        }
        private ObjectSet<Bilhete> _bilhetes;
    
        public ObjectSet<Contato> Contatos
        {
            get { return _contatos  ?? (_contatos = CreateObjectSet<Contato>("Contatos")); }
        }
        private ObjectSet<Contato> _contatos;
    
        public ObjectSet<Indicacao> Indicacoes
        {
            get { return _indicacoes  ?? (_indicacoes = CreateObjectSet<Indicacao>("Indicacoes")); }
        }
        private ObjectSet<Indicacao> _indicacoes;
    
        public ObjectSet<PalpiteCampeao> PalpitesCampeoes
        {
            get { return _palpitesCampeoes  ?? (_palpitesCampeoes = CreateObjectSet<PalpiteCampeao>("PalpitesCampeoes")); }
        }
        private ObjectSet<PalpiteCampeao> _palpitesCampeoes;

        #endregion
    }
}