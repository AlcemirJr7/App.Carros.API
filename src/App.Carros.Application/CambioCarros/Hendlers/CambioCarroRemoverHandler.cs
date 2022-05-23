using App.Carros.Application.CambioCarros.Commands;
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
    public class CambioCarroRemoverHandler : IRequestHandler<CambioCarroRemoverCommand, CambioCarro>
    {
        private readonly ICambioCarroRepositorio _cambioCarroRepositorio;
        public CambioCarroRemoverHandler(ICambioCarroRepositorio cambioCarroRepositorio)
        {
            _cambioCarroRepositorio = cambioCarroRepositorio;
        }

        public async Task<CambioCarro> Handle(CambioCarroRemoverCommand request, CancellationToken cancellationToken)
        {
            var cambioCarro = await _cambioCarroRepositorio.GetCambioCarroPeloIdAsync(request.Id);

            if(cambioCarro == null)
            {
                throw new ApplicationException($"Erro ao criar entidade CambioCarro.");
            }
            else
            {
                return await _cambioCarroRepositorio.DeletarAsync(cambioCarro);
            }
        }
    }
}
