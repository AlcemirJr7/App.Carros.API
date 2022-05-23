using App.Carros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Interfaces
{
    public interface IMarcaCarroService
    {
        Task<IEnumerable<MarcaCarroDTO>> GetMarcaCarrosAsync();

        Task<MarcaCarroDTO> GetMarcasCarroPeloIdAsync(int? id);

        Task CriarAsync(MarcaCarroDTO marcaCarroDto);

        Task AlterarAsync(MarcaCarroDTO marcaCarroDto);

        Task DeletarAsync(int? id);
    }
}
