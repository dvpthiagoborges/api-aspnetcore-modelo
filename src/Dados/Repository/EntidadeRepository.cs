using Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Negocio.Interfaces;
using Negocio.Models;
using Negocio.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repository
{
    public class EntidadeRepository : Repository<Entidade>, IEntidadeRepository
    {
        public EntidadeRepository(ModeloDbContext context) : base(context) {}        

        public async Task<List<Entidade>> ObterEntidadesEnderecos()
        {
            return await Db.Entidades.AsNoTracking()
                .Include(p => p.Endereco)
                .ToListAsync();
        }
    }
}
