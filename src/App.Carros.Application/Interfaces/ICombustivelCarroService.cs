using App.Carros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Interfaces
{
    public interface ICombustivelCarroService
    {
        Task<IEnumerable<CombustivelCarroDTO>> GetCombustivelCarrosAsync();

        Task<CombustivelCarroDTO> GetCombustivelCarroPeloIdAsync(int? id);

        Task CriarAsync(CombustivelCarroDTO combustivelCarroDto);

        Task AlterarAsync(CombustivelCarroDTO combustivelCarroDto);

        Task DeletarAsync(int? id);
    }
}
