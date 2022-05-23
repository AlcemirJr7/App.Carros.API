using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.CombustivelCarros.Queries
{
    public class GetCombustivelCarroPeloIdQuery : IRequest<CombustivelCarro>
    {
        public int Id { get; set; }
        public GetCombustivelCarroPeloIdQuery(int id)
        {
            Id = id;
        }
    }
}
