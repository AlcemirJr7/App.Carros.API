using App.Carros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Interfaces
{
    public interface ICambioCarroService
    {
        Task<IEnumerable<CambioCarroDTO>> GetCambioCarrosAsync();

        Task<CambioCarroDTO> GetCambioCarroPeloIdAsync(int? id);

        Task CriarAsync(CambioCarroDTO cambioCarroDto);

        Task AlterarAsync(CambioCarroDTO cambioCarroDto);

        Task DeletarAsync(int? id);
    }
}
