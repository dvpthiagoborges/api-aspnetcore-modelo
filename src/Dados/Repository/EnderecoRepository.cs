using Dados.Contexto;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ModeloDbContext context) : base(context)
        {
        }
    }
}
