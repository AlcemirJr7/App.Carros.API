using App.Carros.Application.Carros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Carros.Handlers
{
    public class GetCarroPeloIdQueryHandler : IRequestHandler<GetCarroPeloIdQuery, Carro>
    {
        private readonly ICarroRepositorio _carroRepositorio;
        public GetCarroPeloIdQueryHandler(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;

        }
        public async Task<Carro> Handle(GetCarroPeloIdQuery request, CancellationToken cancellationToken)
        {
            return await _carroRepositorio.GetCarroPeloIdAsync(request.Id);
        }
    }
}
