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
    public class CombustivelCarroRemoverCammandHandler : IRequestHandler<CombustivelCarroRemoverCammand, CombustivelCarro>
    {
        private readonly ICombustivelCarroRepositorio _combustivelCarroRepositorio;
        public CombustivelCarroRemoverCammandHandler(ICombustivelCarroRepositorio combustivelCarroRepositorio)
        {
            _combustivelCarroRepositorio = combustivelCarroRepositorio;
        }

        public async Task<CombustivelCarro> Handle(CombustivelCarroRemoverCammand request, CancellationToken cancellationToken)
        {
            var combustivelCarro = await _combustivelCarroRepositorio.GetCombustivelCarroPeloIdAsync(request.Id);

            if(combustivelCarro == null)
            {
                throw new ApplicationException($"Entidade CombustivelCarro não pode ser carregada.");
            }
            else
            {
                return await _combustivelCarroRepositorio.DeletarAsync(combustivelCarro);
            }
        }
    }
}
