using Negocio.Interfaces;
using Negocio.Models;
using Negocio.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class EnderecoService : BaseService, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository,
                               INotificador notificador) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> Adicionar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return false;
            await _enderecoRepository.Adicionar(endereco);
            return true;
        }

        public async Task<bool> Atualizar(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return false;
            await _enderecoRepository.Atualizar(endereco);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _enderecoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _enderecoRepository?.Dispose();
        }
    }
}
