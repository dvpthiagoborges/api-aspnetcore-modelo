using Negocio.Interfaces;
using Negocio.Models;
using Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class EntidadeService : BaseService, IEntidadeService
    {
        private readonly IEntidadeRepository _entidadeRepository;

        public EntidadeService(IEntidadeRepository entidadeRepository,
                              INotificador notificador) : base(notificador)
        {
            _entidadeRepository = entidadeRepository;
        }

        public async Task<bool> Adicionar(Entidade entidade)
        {
            if (!ExecutarValidacao(new EntidadeValidation(), entidade)) return false;

            if (_entidadeRepository.Buscar(p => p.Nome == entidade.Nome).Result.Any())
            {
                Notificar("Já existe uma entidade com esse nome");
                return false;
            }

            await _entidadeRepository.Adicionar(entidade);
            return true;
        }

        public async Task<bool> Atualizar(Entidade entidade)
        {
            if (!ExecutarValidacao(new EntidadeValidation(), entidade)) return false;

            if (_entidadeRepository.Buscar(p => p.Nome == entidade.Nome && p.Id != entidade.Id).Result.Any())
            {
                Notificar("Já existe uma entidade com esse nome");
                return false;
            }

            await _entidadeRepository.Atualizar(entidade);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _entidadeRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _entidadeRepository?.Dispose();
        }
    }
}
