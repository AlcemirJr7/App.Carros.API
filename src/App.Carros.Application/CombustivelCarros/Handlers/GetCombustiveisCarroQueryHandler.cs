using App.Carros.Application.CombustivelCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.CombustivelCarros.Handlers
{
    public class GetCombustiveisCarroQueryHandler : IRequestHandler<GetCombustiveisCarroQuery, IEnumerable<CombustivelCarro>>
    {
        private readonly ICombustivelCarroRepositorio _combustivelCarroRepositorio;
        public GetCombustiveisCarroQueryHandler(ICombustivelCarroRepositorio combustivelCarroRepositorio)
        {
            _combustivelCarroRepositorio = combustivelCarroRepositorio;
        }

        public async Task<IEnumerable<CombustivelCarro>> Handle(GetCombustiveisCarroQuery request, CancellationToken cancellationToken)
        {
            return await _combustivelCarroRepositorio.GetCombustiveisCarroAsync();
        }
    }
}
