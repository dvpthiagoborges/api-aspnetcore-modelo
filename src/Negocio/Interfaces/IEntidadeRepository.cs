using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface IEntidadeRepository : IRepository<Entidade>
    {
        Task<List<Entidade>> ObterEntidadesEnderecos();
    }
}
