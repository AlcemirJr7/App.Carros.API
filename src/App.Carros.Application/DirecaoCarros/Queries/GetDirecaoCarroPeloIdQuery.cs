using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.DirecaoCarros.Queries
{
    public class GetDirecaoCarroPeloIdQuery : IRequest<DirecaoCarro>
    {
        public int Id { get; set; }
        public GetDirecaoCarroPeloIdQuery(int id)
        {
            Id = id;
        }

    }
}
