using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio.Servicos
{
    public class CalculoDoRanking
    {
        private ICampeonatosRepositorio _campeonatoRepositorio;

        public CalculoDoRanking(ICampeonatosRepositorio campeonatoRepositorio)
        {
            _campeonatoRepositorio = campeonatoRepositorio;
        }

        private struct ColocacaoCalculada
        {
            public Jogador Jogador { get; set; }
            public int Pontuacao { get; set; }
            public int AcertosExatos { get; set; }
        }

        public List<Colocacao> Resultado()
        {
            _campeonatoRepositorio.IncluirEtapasJogosApostasJogador = true;
            
            var campeonato = _campeonatoRepositorio.ObterAtual();
            if (campeonato == null)
            {
                return new List<Colocacao>();
            }

            var apostas = new List<Aposta>();
            foreach (var etapa in campeonato.Etapas)
            {
                foreach (var jogo in etapa.Jogos)
                    apostas.AddRange(jogo.Apostas);
            }

            var temp = new List<ColocacaoCalculada>();
            foreach (var grupo in apostas.GroupBy(x => x.Jogador, x => x))
            {
                int pontuacao = 0;
                int acertosExatos = 0;
                foreach (var aposta in grupo)
                {
                    pontuacao += aposta.CalcularPontuacao();
                    acertosExatos += aposta.AcertouExato ? 1 : 0; //critério de desempate
                }
                temp.Add(new ColocacaoCalculada { Jogador = grupo.Key, Pontuacao = pontuacao, AcertosExatos = acertosExatos });
            }

            var posicao = 0;
            var colocacoes = new List<Colocacao>();
            foreach (var item in temp.OrderByDescending(x => x.Pontuacao).ThenByDescending(x => x.AcertosExatos))
            {
                colocacoes.Add(new Colocacao
                {
                    JogadorId = item.Jogador.Id,
                    Posicao = ++posicao,
                    Nickname = item.Jogador.Nickname,
                    Pontuacao = item.Pontuacao
                });
            }

            return colocacoes;
        }
    }
}
