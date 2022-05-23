using App.Carros.Application.MarcaCarros.Commands;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.MarcaCarros.Handlers
{
    public class MarcaCarroCriarCommandHandler : IRequestHandler<MarcaCarroCriarCommand, MarcaCarro>
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        public MarcaCarroCriarCommandHandler(IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }

        public async Task<MarcaCarro> Handle(MarcaCarroCriarCommand request, CancellationToken cancellationToken)
        {
            var marcaCarro = new MarcaCarro(request.Name);

            if(marcaCarro == null)
            {
                throw new ApplicationException($"Entidade MarcaCarro não pode ser carregada.");
            }
            else
            {
                return await _marcaCarroRepositorio.CriarAsync(marcaCarro);
            }
        }
    }
}
