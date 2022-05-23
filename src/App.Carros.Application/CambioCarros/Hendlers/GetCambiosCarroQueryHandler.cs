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
    public class GetCambiosCarroQueryHandler : IRequestHandler<GetCambiosCarroQuery, IEnumerable<CambioCarro>>
    {
        private readonly ICambioCarroRepositorio _cambioCarroRepositorio;
        public GetCambiosCarroQueryHandler(ICambioCarroRepositorio cambioCarroRepositorio)
        {
            _cambioCarroRepositorio = cambioCarroRepositorio;
        }

        public async Task<IEnumerable<CambioCarro>> Handle(GetCambiosCarroQuery request, CancellationToken cancellationToken)
        {
            return await _cambioCarroRepositorio.GetCambioCarrosAsync();
        }
    }
}
