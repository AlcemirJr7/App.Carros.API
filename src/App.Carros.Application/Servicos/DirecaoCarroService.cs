using App.Carros.Application.DirecaoCarros.Commands;
using App.Carros.Application.DirecaoCarros.Queries;
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
    public class DirecaoCarroService : IDirecaoCarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public DirecaoCarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        public async Task AlterarAsync(DirecaoCarroDTO direcaoCarroDto)
        {
            var direcaoCarroAlterarCommand = _mapper.Map<DirecaoCarroAlterarCommand>(direcaoCarroDto);
            await _mediator.Send(direcaoCarroAlterarCommand);
        }

        public async Task CriarAsync(DirecaoCarroDTO direcaoCarroDto)
        {
            var direcaoCarroCriarCommand = _mapper.Map<DirecaoCarroCriarCommand>(direcaoCarroDto);
            await _mediator.Send(direcaoCarroCriarCommand);
        }

        public async Task DeletarAsync(int? id)
        {
            var direcaoCarroRemovereCommand = new DirecaoCarroRemoverCommand(id.Value);

            if (direcaoCarroRemovereCommand == null)
            {
                throw new Exception($"Entidade DirecaoCarro não pode ser carregado.");
            }

            await _mediator.Send(direcaoCarroRemovereCommand);
        }

        public async Task<IEnumerable<DirecaoCarroDTO>> GetDirecaoCarrosAsync()
        {
            var direcaoCarroQuery = new GetDirecoesCarroQuery();

            if (direcaoCarroQuery == null)
            {
                throw new Exception($"Entidade DirecaoCarro não pode ser carregado.");
            }

            var result = await _mediator.Send(direcaoCarroQuery);

            return _mapper.Map<IEnumerable<DirecaoCarroDTO>>(result);
        }

        public async Task<DirecaoCarroDTO> GetDirecaoCarroPeloIdAsync(int? id)
        {
            var direcaoCarroQuery = new GetDirecaoCarroPeloIdQuery(id.Value);
            
            if (direcaoCarroQuery == null)
            {
                throw new Exception($"Entidade DirecaoCarro não pode ser carregado.");
            }

            var result = await _mediator.Send(direcaoCarroQuery);

            return _mapper.Map<DirecaoCarroDTO>(result);


        }
    }
}
