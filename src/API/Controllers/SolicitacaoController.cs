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
    [Route("api/solicitacao")]
    public class SolicitacaoController : MainController
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        private readonly ISolicitacaoService _solicitacaoService;
        private readonly IMapper _mapper;

        public SolicitacaoController(INotificador notificador,
                                     ISolicitacaoRepository solicitacaoRepository,
                                     ISolicitacaoService solicitacaoService,
                                     IMapper mapper) : base(notificador)
        {
            _solicitacaoRepository = solicitacaoRepository;
            _solicitacaoService = solicitacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitacaoViewModel>> ObterTodos()
        {
            var solicitacao = _mapper.Map<IEnumerable<SolicitacaoViewModel>>(await _solicitacaoRepository.ObterTodos());
            return solicitacao;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SolicitacaoViewModel>> ObterPorId(Guid id)
        {
            var solicitacao = _mapper.Map<SolicitacaoViewModel>(await _solicitacaoRepository.ObterPorId(id));
            if (solicitacao == null) return NotFound();
            return solicitacao;
        }

        [HttpPost]
        public async Task<ActionResult<SolicitacaoViewModel>> Adicionar([FromBody]SolicitacaoViewModel solicitacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _solicitacaoService.Adicionar(_mapper.Map<Solicitacao>(solicitacaoViewModel));
            return CustomResponse(solicitacaoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SolicitacaoViewModel>> Atualizar(Guid id, [FromBody]SolicitacaoViewModel solicitacaoViewModel)
        {
            if (id != solicitacaoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(solicitacaoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _solicitacaoService.Atualizar(_mapper.Map<Solicitacao>(solicitacaoViewModel));
            return CustomResponse(solicitacaoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SolicitacaoViewModel>> Excluir(Guid id)
        {
            var solicitacao = _mapper.Map<SolicitacaoViewModel>(await _solicitacaoRepository.ObterPorId(id));
            if (solicitacao == null) return NotFound();
            await _solicitacaoRepository.Remover(id);
            return CustomResponse(solicitacao);
        }
    }
}
