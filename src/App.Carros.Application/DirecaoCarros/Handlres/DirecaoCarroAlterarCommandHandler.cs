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
    public class DirecaoCarroAlterarCommandHandler : IRequestHandler<DirecaoCarroAlterarCommand, DirecaoCarro>
    {
        private readonly IDirecaoCarroRepositorio _direcaoCarroRepositorio;
        public DirecaoCarroAlterarCommandHandler(IDirecaoCarroRepositorio direcaoCarroRepositorio)
        {
            _direcaoCarroRepositorio = direcaoCarroRepositorio;

        }

        public async Task<DirecaoCarro> Handle(DirecaoCarroAlterarCommand request, CancellationToken cancellationToken)
        {
            var direcaoCarro = await _direcaoCarroRepositorio.GetDirecaoCarroPeloIdAsync(request.Id);

            if(direcaoCarro == null)
            {
                throw new ApplicationException($"Entidade DirecaoCarro não pode ser carregada.");
            }
            else 
            {
                direcaoCarro.Update(request.Name);

                return await _direcaoCarroRepositorio.AlterarAsync(direcaoCarro);
            }

            
        }
    }
}
