using App.Carros.Application.CambioCarros.Commands;
using App.Carros.Application.CambioCarros.Queries;
using App.Carros.Application.DTOs;
using App.Carros.Application.Interfaces;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Servicos
{
    public class CambioCarroService : ICambioCarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CambioCarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AlterarAsync(CambioCarroDTO cambioCarroDto)
        {
            var cambioCarroAlterarCommand = _mapper.Map<CambioCarroAlterarCommand>(cambioCarroDto);
            await _mediator.Send(cambioCarroAlterarCommand);
        }

        public async Task CriarAsync(CambioCarroDTO cambioCarroDto)
        {
            var cambioCarroCriarCommand = _mapper.Map<CambioCarroCriarCommand>(cambioCarroDto);
            await _mediator.Send(cambioCarroCriarCommand);
        }

        public async Task DeletarAsync(int? id)
        {
            var cambioCarroRemovereCommand = new CambioCarroRemoverCommand(id.Value);

            if (cambioCarroRemovereCommand == null)
            {
                throw new Exception($"Entidade CambioCarro não pode ser carregado.");
            }

            await _mediator.Send(cambioCarroRemovereCommand);
        }

        public async Task<IEnumerable<CambioCarroDTO>> GetCambioCarrosAsync()
        {
            var CambioCarroQuery = new GetCambiosCarroQuery();

            if (CambioCarroQuery == null)
            {
                throw new Exception($"Entidade não pode ser carregada.");
            }

            var result = await _mediator.Send(CambioCarroQuery);

            return _mapper.Map<IEnumerable<CambioCarroDTO>>(result);
        }

        public async Task<CambioCarroDTO> GetCambioCarroPeloIdAsync(int? id)
        {
            var cambiosCarroQuery = new GetCambioCarroPeloIdQuery(id.Value);

            if(cambiosCarroQuery == null)
            {
                throw new Exception($"Entidade não pode ser carregada.");

            }

            var result = await _mediator.Send(cambiosCarroQuery);

            return _mapper.Map<CambioCarroDTO>(result);
        }
    }
}
