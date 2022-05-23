using App.Carros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Interfaces
{
    public interface IDirecaoCarroService
    {
        Task<IEnumerable<DirecaoCarroDTO>> GetDirecaoCarrosAsync();

        Task<DirecaoCarroDTO> GetDirecaoCarroPeloIdAsync(int? id);

        Task CriarAsync(DirecaoCarroDTO direcaoCarroDto);

        Task AlterarAsync(DirecaoCarroDTO direcaoCarroDto);

        Task DeletarAsync(int? id);
    }
}
