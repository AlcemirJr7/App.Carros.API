using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Carros.Handlers
{
    public abstract class CarroCommand : IRequest<Carro>
    {
        public int Id { get; protected set; }

        public string Name { get; private set; }

        public string Descricao { get; private set; }

        public string Modelo { get; private set; }

        public int Ano { get; private set; }

        public decimal Quilometragem { get; private set; }

        public int Portas { get; private set; }

        public decimal PotenciaMotor { get; private set; }

        public string Placa { get; private set; }

        public decimal Preco { get; private set; }

        public int CambioId { get; set; }

        public int CombustivelId { get; set; }

        public int MarcaId { get; set; }

        public int DirecaoId { get; set; }
    }
}
