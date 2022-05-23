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
    public class DirecaoCarroRemoverCommandHandler : IRequestHandler<DirecaoCarroRemoverCommand, DirecaoCarro>
    {
        private readonly IDirecaoCarroRepositorio _direcaoCarroRepositorio;
        public DirecaoCarroRemoverCommandHandler(IDirecaoCarroRepositorio direcaoCarroRepositorio)
        {
            _direcaoCarroRepositorio = direcaoCarroRepositorio;

        }
        public async Task<DirecaoCarro> Handle(DirecaoCarroRemoverCommand request, CancellationToken cancellationToken)
        {
            var direcaoCarro = await _direcaoCarroRepositorio.GetDirecaoCarroPeloIdAsync(request.Id);

            if(direcaoCarro == null)
            {
                throw new ApplicationException($"Entidade DirecaoCarro não pode ser carregada.");
            }
            else
            {
                return await _direcaoCarroRepositorio.DeletarAsync(direcaoCarro);

            }
        }
    }
}
