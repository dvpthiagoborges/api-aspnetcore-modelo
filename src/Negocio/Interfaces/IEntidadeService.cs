using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IEntidadeService : IDisposable
    {
        Task<bool> Adicionar(Entidade entidade);
        Task<bool> Atualizar(Entidade entidade);
        Task<bool> Remover(Guid id);
    }
}
