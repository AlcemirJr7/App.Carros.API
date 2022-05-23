
using App.Carros.Domain.Entidades;
using MediatR;

namespace App.Carros.Application.CombustivelCarros.Commands
{
    public class CombustivelCarroCammand : IRequest<CombustivelCarro>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
