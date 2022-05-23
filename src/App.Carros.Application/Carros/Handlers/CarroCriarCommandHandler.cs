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
    public class CarroCriarCommandHandler : IRequestHandler<CarroCriarCommand, Carro>
    {
        private readonly ICarroRepositorio _carroRepositorio;
        public CarroCriarCommandHandler(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;

        }

        public async Task<Carro> Handle(CarroCriarCommand request, CancellationToken cancellationToken)
        {
            var carro = new Carro(request.Name,request.Descricao,request.Modelo,request.Ano,request.Quilometragem,request.Portas,request.PotenciaMotor,
                                  request.Placa,request.Preco,request.CambioId,request.CombustivelId,request.MarcaId,request.DirecaoId);

            if(carro == null)
            {
                throw new ApplicationException($"Erro ao criar entidade Carro.");
            }
            else
            {
                carro.CambioId = request.CambioId;
                carro.CombustivelId = request.CombustivelId;
                carro.DirecaoId = request.DirecaoId;                
                carro.MarcaId = request.MarcaId;
                return await _carroRepositorio.CriarAsync(carro);
            }
        }
    }
}
