using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Carros.Handlers
{
    public class CarroRemoverCommandHandler : IRequestHandler<CarroRemoverCommand, Carro>
    {
        private readonly ICarroRepositorio _carroRepositorio;
        public CarroRemoverCommandHandler(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;

        }

        public async Task<Carro> Handle(CarroRemoverCommand request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepositorio.GetCarroPeloIdAsync(request.Id);

            if(carro == null)
            {
                throw new ApplicationException($"Entidade carro não pode ser carregada.");
            }
            else
            {
                var result = await _carroRepositorio.DeletarAsync(carro);

                return result;
            }
        }
    }
}
