using App.Carros.Application.Carros.Handlers;
using App.Carros.Application.Carros.Queries;
using App.Carros.Application.DTOs;
using App.Carros.Application.Interfaces;
using AutoMapper;
using MediatR;


namespace App.Carros.Application.Servicos
{
    public class CarroService : ICarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AlterarAsync(CarroDTO carroDto)
        {
            var carroAlterarCommand = _mapper.Map<CarroAlterarCommand>(carroDto);
            await _mediator.Send(carroAlterarCommand);
            
        }

        public async Task CriarAsync(CarroDTO carroDto)
        {
            var carroCriarCommand = _mapper.Map<CarroCriarCommand>(carroDto);
            await _mediator.Send(carroCriarCommand);

            
        }

        public async Task DeletarAsync(int? id)
        {
            var carroRemovereCommand = new CarroRemoverCommand(id.Value);

            if(carroRemovereCommand == null)
            {
                throw new Exception($"Entidade carro não pode ser carregado.");
            }

            await _mediator.Send(carroRemovereCommand);
        }

        public async Task<CarroDTO> GetCarroPeloIdAsync(int? id)
        {
            var carroPeloId = new GetCarroPeloIdQuery(id.Value);
            
            if (carroPeloId == null)
            {
                throw new Exception($"Entidade carro não pode ser carregado.");
            }

            var result = await _mediator.Send(carroPeloId);

            return _mapper.Map<CarroDTO>(result);
        }

        public async Task<IEnumerable<CarroDTO>> GetCarrosAsync()
        {
            var carroQuery = new GetCarrosQuery();

            if(carroQuery == null)
            {
                throw new Exception($"Entidade não pode ser carregada.");
            }

            var result = await _mediator.Send(carroQuery);

            return _mapper.Map<IEnumerable<CarroDTO>>(result);
        }
    }
}
