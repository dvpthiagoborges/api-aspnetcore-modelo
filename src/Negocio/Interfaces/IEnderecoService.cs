using Negocio.Models;
using System;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IEnderecoService : IDisposable
    {
        Task<bool> Adicionar(Endereco endereco);
        Task<bool> Atualizar(Endereco endereco);
        Task<bool> Remover(Guid id);
    }
}
