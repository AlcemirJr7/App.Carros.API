using App.Carros.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Application.Interfaces
{
    public interface ICarroService
    {
        Task<IEnumerable<CarroDTO>> GetCarrosAsync();

        Task<CarroDTO> GetCarroPeloIdAsync(int? id);

        Task CriarAsync(CarroDTO carroDto);

        Task AlterarAsync(CarroDTO carroDto);

        Task DeletarAsync(int? id);
    }
}
