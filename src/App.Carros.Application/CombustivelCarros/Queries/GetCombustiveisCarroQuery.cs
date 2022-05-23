using App.Carros.Domain.Entidades;
using MediatR;


namespace App.Carros.Application.CombustivelCarros.Queries
{
    public class GetCombustiveisCarroQuery : IRequest<IEnumerable<CombustivelCarro>>
    {
    }
}
