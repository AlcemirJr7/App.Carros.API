using App.Carros.Application.MarcaCarros.Commands;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;


namespace App.Carros.Application.MarcaCarros.Handlers
{
    public class MarcaCarroRemoverCommandHandler : IRequestHandler<MarcaCarroRemoverCommand, MarcaCarro>
    {
        private readonly IMarcaCarroRepositorio _marcaCarroRepositorio;
        public MarcaCarroRemoverCommandHandler(IMarcaCarroRepositorio marcaCarroRepositorio)
        {
            _marcaCarroRepositorio = marcaCarroRepositorio;
        }

        public async Task<MarcaCarro> Handle(MarcaCarroRemoverCommand request, CancellationToken cancellationToken)
        {
            var marcaCarro = await _marcaCarroRepositorio.GetMarcaCarroPeloIdAsync(request.Id);

            if(marcaCarro == null)
            {
                throw new ApplicationException($"Entidade MarcaCarro não pode ser carregada.");
            }
            else
            {
                return await _marcaCarroRepositorio.DeletarAsync(marcaCarro);
            }
        }
    }
}
