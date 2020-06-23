using Dados.Contexto;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Repository
{
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(ModeloDbContext context) : base(context)
        {
        }
    }
}
