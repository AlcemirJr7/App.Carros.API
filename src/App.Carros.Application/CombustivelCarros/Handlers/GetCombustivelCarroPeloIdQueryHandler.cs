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
    public class GetCombustivelCarroPeloIdQueryHandler : IRequestHandler<GetCombustivelCarroPeloIdQuery, CombustivelCarro>
    {
        private readonly ICombustivelCarroRepositorio _combustivelCarroRepositorio;
        public GetCombustivelCarroPeloIdQueryHandler(ICombustivelCarroRepositorio combustivelCarroRepositorio)
        {
            _combustivelCarroRepositorio = combustivelCarroRepositorio;

        }
        public async Task<CombustivelCarro> Handle(GetCombustivelCarroPeloIdQuery request, CancellationToken cancellationToken)
        {
            return await _combustivelCarroRepositorio.GetCombustivelCarroPeloIdAsync(request.Id);
        }
    }
}
