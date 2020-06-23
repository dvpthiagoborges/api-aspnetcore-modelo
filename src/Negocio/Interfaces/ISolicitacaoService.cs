using Negocio.Models;
using System;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface ISolicitacaoService : IDisposable
    {
        Task<bool> Adicionar(Solicitacao solicitacao);
        Task<bool> Atualizar(Solicitacao solicitacao);
        Task<bool> Remover(Guid id);
    }
}
