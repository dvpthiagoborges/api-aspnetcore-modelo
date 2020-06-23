using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/endereco")]
    public class EnderecoController : MainController
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecoController(INotificador notificador,
                                  IEnderecoRepository enderecoRepository,
                                  IEnderecoService enderecoService,
                                  IMapper mapper) : base(notificador)
        {
            _enderecoRepository = enderecoRepository;
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EnderecoViewModel>> ObterTodos()
        {
            var endereco = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterTodos());
            return endereco;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> ObterPorId(Guid id)
        {
            var endereco = _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
            if (endereco == null) return NotFound();
            return endereco;
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoViewModel>> Adicionar([FromBody]EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _enderecoService.Adicionar(_mapper.Map<Endereco>(enderecoViewModel));
            return CustomResponse(enderecoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> Atualizar(Guid id, [FromBody]EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _enderecoService.Atualizar(_mapper.Map<Endereco>(enderecoViewModel));
            return CustomResponse(enderecoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> Excluir(Guid id)
        {
            var endereco = _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
            if (endereco == null) return NotFound();
            await _enderecoRepository.Remover(id);
            return CustomResponse(endereco);
        }
    }
}
