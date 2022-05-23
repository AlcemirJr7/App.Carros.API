using App.Carros.Domain.Entidades;
using MediatR;


namespace App.Carros.Application.CambioCarros.Queries
{
    public class GetCambiosCarroQuery : IRequest<IEnumerable<CambioCarro>>
    {
    }
}
