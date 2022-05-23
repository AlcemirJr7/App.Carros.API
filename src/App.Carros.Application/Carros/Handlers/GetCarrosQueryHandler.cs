using App.Carros.Application.Carros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;


namespace App.Carros.Application.Carros.Handlers
{
    public class GetCarrosQueryHandler : IRequestHandler<GetCarrosQuery, IEnumerable<Carro>>
    {
        private readonly ICarroRepositorio _carroRepositorio;
        public GetCarrosQueryHandler(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;   

        }
        public async Task<IEnumerable<Carro>> Handle(GetCarrosQuery request, CancellationToken cancellationToken)
        {
            return await _carroRepositorio.GetCarrosAsync();
        }
    }
}
