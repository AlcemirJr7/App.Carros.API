using App.Carros.Application.DirecaoCarros.Commands;
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
    public class DirecaoCarroCriarCommandHandler : IRequestHandler<DirecaoCarroCriarCommand, DirecaoCarro>
    {
        private readonly IDirecaoCarroRepositorio _direcaoCarroRepositorio;
        public DirecaoCarroCriarCommandHandler(IDirecaoCarroRepositorio direcaoCarroRepositorio)
        {
            _direcaoCarroRepositorio = direcaoCarroRepositorio;

        }

        public async Task<DirecaoCarro> Handle(DirecaoCarroCriarCommand request, CancellationToken cancellationToken)
        {
            var direcaoCarro = new DirecaoCarro(request.Name);

            if(direcaoCarro == null)
            {
                throw new ApplicationException($"Entidade DirecaoCarro não pode ser carregada.");
            }
            else
            {
                return await _direcaoCarroRepositorio.CriarAsync(direcaoCarro);
            }

            
        }
    }
}
