using App.Carros.Application.CombustivelCarros.Commands;
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
    public class CombustivelCarroCriarCammandHandler : IRequestHandler<CombustivelCarroCriarCammand, CombustivelCarro>
    {
        private readonly ICombustivelCarroRepositorio _combustivelCarroRepositorio;
        public CombustivelCarroCriarCammandHandler(ICombustivelCarroRepositorio combustivelCarroRepositorio)
        {
            _combustivelCarroRepositorio = combustivelCarroRepositorio;
        }

        public async Task<CombustivelCarro> Handle(CombustivelCarroCriarCammand request, CancellationToken cancellationToken)
        {
            var combustivelCarro = new CombustivelCarro(request.Name);
            
            if(combustivelCarro == null)
            {
                throw new ApplicationException($"Entidade CombustivelCarro não pode ser carregada.");
            }
            else
            {
                return await _combustivelCarroRepositorio.CriarAsync(combustivelCarro);
            }
        }
    }
}
