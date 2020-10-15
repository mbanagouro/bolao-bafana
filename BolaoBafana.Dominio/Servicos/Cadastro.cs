using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoBafana.Dominio.Servicos
{
    public class Cadastro
    {
        private IUnitOfWork _unitOfWork;

        public Cadastro(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Salvar(Guid tokenIndicacao, Jogador jogador)
        {
            var jogadorExiste = _unitOfWork.JogadoresRepositorio.ObterPorEmail(jogador.Email);
            if (jogadorExiste != null)
                throw new ApplicationException("Já existe um jogador utilizando este email.");

            var indicacao = _unitOfWork.IndicacoesRepositorio.ObterPorToken(tokenIndicacao);
            if (indicacao == null)
                throw new ApplicationException("Token de indicação inválido.");

            //Insere novo jogador
            _unitOfWork.JogadoresRepositorio.Inserir(jogador);

            //Confirma cadastro por indicação
            indicacao.Cadastrou = true;
            _unitOfWork.IndicacoesRepositorio.Atualizar(indicacao);

            _unitOfWork.Commit();
        }
    }
}
