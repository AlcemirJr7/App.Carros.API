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
    public class CambioCarroAlterarHandler : IRequestHandler<CambioCarroAlterarCommand, CambioCarro>
    {
        private readonly ICambioCarroRepositorio _cambioCarroRepositorio;
        public CambioCarroAlterarHandler(ICambioCarroRepositorio cambioCarroRepositorio)
        {
            _cambioCarroRepositorio = cambioCarroRepositorio;
        }
        public async Task<CambioCarro> Handle(CambioCarroAlterarCommand request, CancellationToken cancellationToken)
        {
            var cambioCarro = await _cambioCarroRepositorio.GetCambioCarroPeloIdAsync(request.Id);

            if(cambioCarro == null)
            {
                throw new ApplicationException($"Erro ao criar entidade CambioCarro.");
            }
            else
            {
                cambioCarro.Update(request.Name);
                return await _cambioCarroRepositorio.AlterarAsync(cambioCarro);
            }

        }
    }
}
