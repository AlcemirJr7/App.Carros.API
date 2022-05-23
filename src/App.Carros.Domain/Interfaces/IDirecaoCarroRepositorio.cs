using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Interfaces
{
    public interface IDirecaoCarroRepositorio
    {
        Task<IEnumerable<DirecaoCarro>> GetDirecaoCarrosAsync();

        Task<DirecaoCarro> GetDirecaoCarroPeloIdAsync(int? id);

        Task<DirecaoCarro> CriarAsync(DirecaoCarro direcaoCarro);

        Task<DirecaoCarro> AlterarAsync(DirecaoCarro direcaoCarro);

        Task<DirecaoCarro> DeletarAsync(DirecaoCarro direcaoCarro);
    }
}
