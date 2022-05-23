using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.MarcaCarros.Commands
{
    public class MarcaCarroCommand : IRequest<MarcaCarro>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
