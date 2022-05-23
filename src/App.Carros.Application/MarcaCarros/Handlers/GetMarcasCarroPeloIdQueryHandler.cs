using App.Carros.Application.MarcaCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.MarcaCarros.Handlers
{
    public class GetMarcasCarroPeloIdQueryHandler : IRequestHandler<GetMarcasCarroPeloIdQuery, MarcaCarro>
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        public GetMarcasCarroPeloIdQueryHandler(IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }
        public async Task<MarcaCarro> Handle(GetMarcasCarroPeloIdQuery request, CancellationToken cancellationToken)
        {
            return await _marcaCarroRepositorio.GetMarcaCarroPeloIdAsync(request.Id);
        }
    }
}
