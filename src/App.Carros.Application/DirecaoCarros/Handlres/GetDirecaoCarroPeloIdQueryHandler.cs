using App.Carros.Application.DirecaoCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;

namespace App.Carros.Application.DirecaoCarros.Handlres
{
    public class GetDirecaoCarroPeloIdQueryHandler : IRequestHandler<GetDirecaoCarroPeloIdQuery, DirecaoCarro>
    {
        private readonly IDirecaoCarroRepositorio _direcaoCarroRepositorio;
        public GetDirecaoCarroPeloIdQueryHandler(IDirecaoCarroRepositorio direcaoCarroRepositorio)
        {
            _direcaoCarroRepositorio = direcaoCarroRepositorio;
        }
        public async Task<DirecaoCarro> Handle(GetDirecaoCarroPeloIdQuery request, CancellationToken cancellationToken)
        {
            return await _direcaoCarroRepositorio.GetDirecaoCarroPeloIdAsync(request.Id);
        }
    }
}
