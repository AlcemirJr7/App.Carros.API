using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Interfaces
{
    public interface ICombustivelCarroRepositorio
    {
        Task<IEnumerable<CombustivelCarro>> GetCombustiveisCarroAsync();

        Task<CombustivelCarro> GetCombustivelCarroPeloIdAsync(int? id);

        Task<CombustivelCarro> CriarAsync(CombustivelCarro combustivelCarro);

        Task<CombustivelCarro> AlterarAsync(CombustivelCarro combustivelCarro);

        Task<CombustivelCarro> DeletarAsync(CombustivelCarro combustivelCarro);
    }
}
