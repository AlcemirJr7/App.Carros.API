
using App.Carros.Application.CombustivelCarros.Commands;
using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;

namespace App.Carros.Application.CombustivelCarros.Handlers
{
    public class CombustivelCarroAlterarCammandHandler : IRequestHandler<CombustivelCarroAlterarCammand, CombustivelCarro>
    {
        private readonly ICombustivelCarroRepositorio _combustivelCarroRepositorio;
        public CombustivelCarroAlterarCammandHandler(ICombustivelCarroRepositorio combustivelCarroRepositorio)
        {
            _combustivelCarroRepositorio = combustivelCarroRepositorio;
        }
        public async Task<CombustivelCarro> Handle(CombustivelCarroAlterarCammand request, CancellationToken cancellationToken)
        {
            var combustivelCarro = await _combustivelCarroRepositorio.GetCombustivelCarroPeloIdAsync(request.Id);

            if(combustivelCarro == null)
            {
                throw new ApplicationException($"Entidade CombustivelCarro não pode ser carregada.");
            }
            else
            {
                combustivelCarro.Update(request.Name);

                return await _combustivelCarroRepositorio.AlterarAsync(combustivelCarro);
            }
        }
    }
}
