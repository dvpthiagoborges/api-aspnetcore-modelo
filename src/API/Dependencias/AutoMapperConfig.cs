using API.ViewModels;
using AutoMapper;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dependencias
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entidade, EntidadeViewModel>().ReverseMap();
            CreateMap<Solicitacao, SolicitacaoViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
