using App.Carros.Application.CambioCarros.Commands;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;

namespace App.Carros.Application.CambioCarros.Hendlers
{
    public class CambioCarroCriarHandler : IRequestHandler<CambioCarroCriarCommand, CambioCarro>
    {
        private readonly ICambioCarroRepositorio _cambioCarroRepositorio;
        public CambioCarroCriarHandler(ICambioCarroRepositorio cambioCarroRepositorio)
        {
            _cambioCarroRepositorio = cambioCarroRepositorio;
        }

        public async Task<CambioCarro> Handle(CambioCarroCriarCommand request, CancellationToken cancellationToken)
        {
            var cambioCarro = new CambioCarro(request.Name);

            if(cambioCarro == null)
            {
                throw new ApplicationException($"Erro ao criar entidade CambioCarro.");
            }
            else
            {
                return await _cambioCarroRepositorio.CriarAsync(cambioCarro);
            }


        }
    }
}
