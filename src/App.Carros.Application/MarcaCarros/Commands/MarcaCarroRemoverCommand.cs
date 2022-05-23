using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.MarcaCarros.Commands
{
    public class MarcaCarroRemoverCommand : IRequest<MarcaCarro>
    {
        public int Id { get; set; }

        public MarcaCarroRemoverCommand(int id)
        {
            Id = id;
        }
    }
}
