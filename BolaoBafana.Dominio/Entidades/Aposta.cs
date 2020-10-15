using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nbr.Core;

namespace BolaoBafana.Dominio
{
    public class Aposta : Entidade
    {
        public Jogador Jogador { get; set; }
        public int JogadorId { get; protected set; }
        
        public Jogo Jogo { get; set; }
        public int JogoId { get; protected set; }

        public DateTime Data { get; protected set; }

        public Placar Palpite { get; set; }

        public Aposta() 
        {
            Data = DateTime.Now;
            Palpite = new Placar();
        }

        public Aposta(Jogo jogo, Jogador jogador) 
            :this()
        {
            Jogo = jogo;
            JogoId = jogo.Id;
            Jogador = jogador;
            JogadorId = jogador.Id;
        }

        public void Palpitar(Placar palpite)
        {
            Palpite = palpite ?? new Placar();
            Data = DateTime.Now;
        }

        #region Cálculo de acerto

        public bool AcertouExato { get; protected set; }

        public int CalcularPontuacao()
        {
            return CalcularPontuacao(this.Jogo);
        }

        public int CalcularPontuacao(Jogo jogo)
        {
            var resultado = jogo.Resultado;

            //Se o jogo ainda não foi finalizado...
            if (!resultado.Finalizado)
                return 0;
            //Se o jogo foi finalizado, mas o jogador não palpitou...
            if (resultado.Finalizado && !Palpite.Finalizado)
                return 0;

            var peso = jogo.Etapa.Peso;
            int palpiteTimeDaCasa = Palpite.TimeDaCasa.Value;
            int palpiteTimeVisitante = Palpite.TimeVisitante.Value;
            int resultadoTimeDaCasa = resultado.TimeDaCasa.Value;
            int resultadoTimeVisitante = resultado.TimeVisitante.Value;
            
            //Se o jogo acabou sem empate...
            if (!resultado.Empatou)
            {
                //Acertou em cheio
                if (palpiteTimeDaCasa == resultadoTimeDaCasa && palpiteTimeVisitante == resultadoTimeVisitante)
                {
                    AcertouExato = true;
                    return 10 * peso;
                }
                //Acertou o vencedor e 1 dos placares
                else if ((palpiteTimeDaCasa < palpiteTimeVisitante && resultadoTimeDaCasa < resultadoTimeVisitante ||
                          palpiteTimeDaCasa > palpiteTimeVisitante && resultadoTimeDaCasa > resultadoTimeVisitante) &&
                         (palpiteTimeDaCasa == resultadoTimeDaCasa || palpiteTimeVisitante == resultadoTimeVisitante))
                {
                    return 6 * peso;
                }
                //Acertou o vencedor, mas errou os placares
                else if ((palpiteTimeDaCasa < palpiteTimeVisitante && resultadoTimeDaCasa < resultadoTimeVisitante ||
                          palpiteTimeDaCasa > palpiteTimeVisitante && resultadoTimeDaCasa > resultadoTimeVisitante))
                {
                    return 3 * peso;
                }
                //Não acertou o vencedor
                else
                {
                    return 0;
                }
            }
            //Se o jogo acabou empatado...
            else
            {
                //Se o jogador não palpitou como empate...
                if (!Palpite.Empatou)
                    return 0;
                
                //Se o jogo acabou nos penaltis...
                if (resultado.EncerrouNosPenaltis)
                {
                    //Se o jogador não palpitou com encerramento nos penaltis...
                    if (!Palpite.EncerrouNosPenaltis)
                        return 0;

                    bool acertouVencedor = false;
                    if (Palpite.TimeDaCasaVenceuNosPenaltis && resultado.TimeDaCasaVenceuNosPenaltis)
                    {
                        acertouVencedor = true;
                    }
                    else if (Palpite.TimeVisitanteVenceuNosPenaltis && resultado.TimeVisitanteVenceuNosPenaltis)
                    {
                        acertouVencedor = true;
                    }

                    //Acertou o placar e o vencedor
                    if (palpiteTimeDaCasa == resultadoTimeDaCasa &&
                        palpiteTimeVisitante == resultadoTimeVisitante &&
                        acertouVencedor)
                    {
                        AcertouExato = true;
                        return 10 * peso;
                    }
                    //Acertou o placar, mas não acertou o vencedor
                    else if (palpiteTimeDaCasa == resultadoTimeDaCasa &&
                             palpiteTimeVisitante == resultadoTimeVisitante &&
                             !acertouVencedor)
                    {
                        return 7 * peso;
                    }
                    //Acertou o vencedor, mas errou os placares
                    else if ((palpiteTimeDaCasa != resultadoTimeDaCasa || palpiteTimeDaCasa != palpiteTimeVisitante) &&
                             acertouVencedor)
                    {
                        return 5 * peso;
                    }
                    //Acertou somente empate
                    else
                    {
                        return 3 * peso;
                    }
                }
                else
                {
                    //Acertou o placar
                    if (palpiteTimeDaCasa == resultadoTimeDaCasa && palpiteTimeVisitante == resultadoTimeVisitante)
                    {
                        AcertouExato = true;
                        return 10 * peso;
                    }
                    //Acertou somente empate
                    else
                    {
                        return 3 * peso;
                    }
                }
            }
        }

        #endregion
    }
}
