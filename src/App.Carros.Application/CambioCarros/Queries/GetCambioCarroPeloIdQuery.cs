using MediatR;
using App.Carros.Domain.Entidades;

namespace App.Carros.Application.CambioCarros.Queries
{
    public class GetCambioCarroPeloIdQuery : IRequest<CambioCarro>
    {
        public int Id { get; set; }
        public GetCambioCarroPeloIdQuery(int id)
        {
            Id = id;
        }

    }
}
