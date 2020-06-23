using Negocio.Interfaces;
using Negocio.Models;
using Negocio.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class SolicitacaoService : BaseService, ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(INotificador notificador,
                                  ISolicitacaoRepository solicitacaoRepository) : base(notificador)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<bool> Adicionar(Solicitacao solicitacao)
        {
            if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return false;

            if (_solicitacaoRepository.Buscar(p => p.Descricao == solicitacao.Descricao).Result.Any())
            {
                Notificar("Já existe uma solicitação com esse nome");
                return false;
            }

            await _solicitacaoRepository.Adicionar(solicitacao);
            return true;
        }

        public async Task<bool> Atualizar(Solicitacao solicitacao)
        {
            if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return false;

            if (_solicitacaoRepository.Buscar(p => p.Descricao == solicitacao.Descricao && p.Id != solicitacao.Id).Result.Any())
            {
                Notificar("Já existe uma solicitação com esse nome");
                return false;
            }

            await _solicitacaoRepository.Atualizar(solicitacao);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _solicitacaoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _solicitacaoRepository?.Dispose();
        }
    }
}
