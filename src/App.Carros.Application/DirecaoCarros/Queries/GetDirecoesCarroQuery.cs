using App.Carros.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.DirecaoCarros.Queries
{
    public class GetDirecoesCarroQuery : IRequest<IEnumerable<DirecaoCarro>>
    {
    }
}
