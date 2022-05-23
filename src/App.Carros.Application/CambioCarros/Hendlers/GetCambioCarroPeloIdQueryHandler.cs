using App.Carros.Application.CambioCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.CambioCarros.Hendlers
{
    public class GetCambioCarroPeloIdQueryHandler : IRequestHandler<GetCambioCarroPeloIdQuery, CambioCarro>
    {
        private readonly ICambioCarroRepositorio _cambioCarroRepositorio;
        public GetCambioCarroPeloIdQueryHandler(ICambioCarroRepositorio cambioCarroRepositorio)
        {
            _cambioCarroRepositorio = cambioCarroRepositorio;
        }

        public async Task<CambioCarro> Handle(GetCambioCarroPeloIdQuery request, CancellationToken cancellationToken)
        {
            return await _cambioCarroRepositorio.GetCambioCarroPeloIdAsync(request.Id);            
        }
    }
}
