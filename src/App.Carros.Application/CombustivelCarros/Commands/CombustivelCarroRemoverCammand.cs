
using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.CombustivelCarros.Commands
{
    public class CombustivelCarroRemoverCammand : IRequest<CombustivelCarro>
    {
        public int Id { get; set; }

        public CombustivelCarroRemoverCammand(int id)
        {
            Id = id;
        }
    }
}
