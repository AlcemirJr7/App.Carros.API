using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.DirecaoCarros.Commands
{
    public class DirecaoCarroRemoverCommand : IRequest<DirecaoCarro>
    {
        public int Id { get; set; }

        public DirecaoCarroRemoverCommand(int id)
        {
            Id = id;
        }
    }
}
