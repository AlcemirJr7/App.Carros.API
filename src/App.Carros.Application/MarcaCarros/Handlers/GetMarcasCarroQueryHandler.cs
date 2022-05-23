using App.Carros.Application.MarcaCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;


namespace App.Carros.Application.MarcaCarros.Handlers
{
    public class GetMarcasCarroQueryHandler : IRequestHandler<GetMarcasCarroQuery, IEnumerable<MarcaCarro>>
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        public GetMarcasCarroQueryHandler(IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }
        public async Task<IEnumerable<MarcaCarro>> Handle(GetMarcasCarroQuery request, CancellationToken cancellationToken)
        {
            return await _marcaCarroRepositorio.GetMarcaCarroAsync();
        }
    }
}
