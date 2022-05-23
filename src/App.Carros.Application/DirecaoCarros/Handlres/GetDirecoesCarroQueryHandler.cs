using App.Carros.Application.DirecaoCarros.Queries;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.DirecaoCarros.Handlres
{
    public class GetDirecoesCarroQueryHandler : IRequestHandler<GetDirecoesCarroQuery, IEnumerable<DirecaoCarro>>
    {
        private readonly IDirecaoCarroRepositorio _direcaoCarroRepositorio;
        public GetDirecoesCarroQueryHandler(IDirecaoCarroRepositorio direcaoCarroRepositorio)
        {
            _direcaoCarroRepositorio = direcaoCarroRepositorio;
        }

        public async Task<IEnumerable<DirecaoCarro>> Handle(GetDirecoesCarroQuery request, CancellationToken cancellationToken)
        {
            return await _direcaoCarroRepositorio.GetDirecaoCarrosAsync();
        }
    }
}
