using App.Carros.Application.CombustivelCarros.Commands;
using App.Carros.Application.CombustivelCarros.Queries;
using App.Carros.Application.DTOs;
using App.Carros.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Servicos
{
    public class CombustivelCarroService : ICombustivelCarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CombustivelCarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        public async Task AlterarAsync(CombustivelCarroDTO combustivelCarroDto)
        {
            var combustivelCarroAlterarCommand = _mapper.Map<CombustivelCarroAlterarCammand>(combustivelCarroDto);
            await _mediator.Send(combustivelCarroAlterarCommand);
        }

        public async Task CriarAsync(CombustivelCarroDTO combustivelCarroDto)
        {
            var combustivelCarroCriarCommand = _mapper.Map<CombustivelCarroCriarCammand>(combustivelCarroDto);
            await _mediator.Send(combustivelCarroCriarCommand);
        }

        public async Task DeletarAsync(int? id)
        {
            var combustivelCarroRemovereCommand = new CombustivelCarroRemoverCammand(id.Value);

            if (combustivelCarroRemovereCommand == null)
            {
                throw new Exception($"Entidade CombustivelCarro não pode ser carregado.");
            }

            await _mediator.Send(combustivelCarroRemovereCommand);
        }

        public async Task<IEnumerable<CombustivelCarroDTO>> GetCombustivelCarrosAsync()
        {
            var combustivelCarroQuery = new GetCombustiveisCarroQuery();

            if (combustivelCarroQuery == null)
            {
                throw new Exception($"Entidade CombustivelCarro não pode ser carregado.");
            }

            var result = await _mediator.Send(combustivelCarroQuery);

            return _mapper.Map<IEnumerable<CombustivelCarroDTO>>(result);


        }

        public async Task<CombustivelCarroDTO> GetCombustivelCarroPeloIdAsync(int? id)
        {
            var combustivelCarroQuery = new GetCombustivelCarroPeloIdQuery(id.Value);

            if (combustivelCarroQuery == null)
            {
                throw new Exception($"Entidade CombustivelCarro não pode ser carregada.");
            }

            var result = await _mediator.Send(combustivelCarroQuery);

            return _mapper.Map<CombustivelCarroDTO>(result);
        }
    }
}
