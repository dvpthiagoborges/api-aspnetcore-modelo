using API.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Interfaces;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/entidade")]
    public class EntidadeController : MainController
    {
        private readonly IEntidadeRepository _entidadeRepository;
        private readonly IEntidadeService _entidadeService;
        private readonly IMapper _mapper;

        public EntidadeController(INotificador notificador,
                                  IEntidadeRepository entidadeRepository,
                                  IEntidadeService entidadeService,
                                  IMapper mapper) : base(notificador)
        {
            _entidadeRepository = entidadeRepository;
            _entidadeService = entidadeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EntidadeViewModel>> ObterTodos()
        {
            var entidade = _mapper.Map<IEnumerable<EntidadeViewModel>>(await _entidadeRepository.ObterEntidadesEnderecos());
            return entidade;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EntidadeViewModel>> ObterPorId(Guid id)
        {
            var entidade = _mapper.Map<EntidadeViewModel>(await _entidadeRepository.ObterPorId(id));
            if (entidade == null) return NotFound();
            return entidade;
        }

        [HttpPost]
        public async Task<ActionResult<EntidadeViewModel>> Adicionar([FromBody]EntidadeViewModel entidadeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _entidadeService.Adicionar(_mapper.Map<Entidade>(entidadeViewModel));
            return CustomResponse(entidadeViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EntidadeViewModel>> Atualizar(Guid id, [FromBody]EntidadeViewModel entidadeViewModel)
        {
            if (id != entidadeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(entidadeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _entidadeService.Atualizar(_mapper.Map<Entidade>(entidadeViewModel));
            return CustomResponse(entidadeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EntidadeViewModel>> Excluir(Guid id)
        {
            var entidade = _mapper.Map<EntidadeViewModel>(await _entidadeRepository.ObterPorId(id));
            if (entidade == null) return NotFound();
            await _entidadeRepository.Remover(id);
            return CustomResponse(entidade);
        }        
    }
}
