using App.Carros.Application.DTOs;
using App.Carros.Application.Interfaces;
using App.Carros.Application.MarcaCarros.Commands;
using App.Carros.Application.MarcaCarros.Queries;
using AutoMapper;
using MediatR;


namespace App.Carros.Application.Servicos
{
    public class MarcaCarroService : IMarcaCarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public MarcaCarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        public async Task AlterarAsync(MarcaCarroDTO marcaCarroDto)
        {
            var marcaCarroAlterarCommand = _mapper.Map<MarcaCarroAlterarCommand>(marcaCarroDto);
            await _mediator.Send(marcaCarroAlterarCommand);
        }

        public async Task CriarAsync(MarcaCarroDTO marcaCarroDto)
        {
            var marcaCarroCriarCommand = _mapper.Map<MarcaCarroCriarCommand>(marcaCarroDto);
            await _mediator.Send(marcaCarroCriarCommand);
        }

        public async Task DeletarAsync(int? id)
        {
            var marcaCarroRemovereCommand = new MarcaCarroRemoverCommand(id.Value);

            if (marcaCarroRemovereCommand == null)
            {
                throw new Exception($"Entidade MarcaCarro não pode ser carregado.");
            }

            await _mediator.Send(marcaCarroRemovereCommand);
        }

        public async Task<IEnumerable<MarcaCarroDTO>> GetMarcaCarrosAsync()
        {
            var marcaCarroQuery = new GetMarcasCarroQuery();

            if (marcaCarroQuery == null)
            {
                throw new Exception($"Entidade MarcaCarro não pode ser carregado.");
            }

            var result = await _mediator.Send(marcaCarroQuery);

            return _mapper.Map<IEnumerable<MarcaCarroDTO>>(result);
        }

        public async Task<MarcaCarroDTO> GetMarcasCarroPeloIdAsync(int? id)
        {
            var marcaCarroQuery = new GetMarcasCarroPeloIdQuery(id.Value);

            if (marcaCarroQuery == null)
            {
                throw new Exception($"Entidade MarcaCarro não pode ser carregado.");
            }

            var result = await _mediator.Send(marcaCarroQuery);

            return _mapper.Map<MarcaCarroDTO>(result);
        }
    }
}
