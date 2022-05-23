
using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.CambioCarros.Commands
{
    public class CambioCarroCommand : IRequest<CambioCarro>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
