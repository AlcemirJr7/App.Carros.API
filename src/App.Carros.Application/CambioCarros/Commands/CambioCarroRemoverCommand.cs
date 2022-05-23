
using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.CambioCarros.Commands
{
    public class CambioCarroRemoverCommand : IRequest<CambioCarro>
    {
        public int Id { get; set; }

        public CambioCarroRemoverCommand(int id)
        {
            Id = id;
        }
    }
}
