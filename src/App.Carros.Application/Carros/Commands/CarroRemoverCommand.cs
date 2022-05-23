using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Carros.Handlers
{
    public class CarroRemoverCommand : IRequest<Carro>
    {
        public int Id { get; set; }

        public CarroRemoverCommand(int id)
        {
            Id = id;
        }
    }
}
