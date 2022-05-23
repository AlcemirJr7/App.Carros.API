using App.Carros.Domain.Entidades;
using MediatR;


namespace App.Carros.Application.MarcaCarros.Queries
{
    public class GetMarcasCarroPeloIdQuery : IRequest<MarcaCarro>
    {
        public int Id { get; set; }
        public GetMarcasCarroPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
