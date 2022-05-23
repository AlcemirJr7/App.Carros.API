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
    public class MarcaCarroAlterarCommandHandler : IRequestHandler<MarcaCarroAlterarCommand, MarcaCarro>
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        public MarcaCarroAlterarCommandHandler(IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }

        public async Task<MarcaCarro> Handle(MarcaCarroAlterarCommand request, CancellationToken cancellationToken)
        {
            var marcaCarro = await _marcaCarroRepositorio.GetMarcaCarroPeloIdAsync(request.Id);

            if(marcaCarro == null)
            {
                throw new ApplicationException($"Entidade MarcaCarro não pode ser carregada.");
            }
            else
            {
                marcaCarro.Update(request.Name);
                return await _marcaCarroRepositorio.AlterarAsync(marcaCarro);
            }
        }
    }
}
