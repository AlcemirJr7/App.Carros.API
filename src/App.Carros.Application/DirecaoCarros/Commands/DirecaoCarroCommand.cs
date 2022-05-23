using App.Carros.Domain.Entidades;
using MediatR;


namespace App.Carros.Application.DirecaoCarros.Commands
{
    public class DirecaoCarroCommand : IRequest<DirecaoCarro>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
