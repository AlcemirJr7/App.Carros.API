using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Interfaces
{
    public interface IMarcaCarroRepositorio
    {
        Task<IEnumerable<MarcaCarro>> GetMarcaCarroAsync();

        Task<MarcaCarro> GetMarcaCarroPeloIdAsync(int? id);

        Task<MarcaCarro> CriarAsync(MarcaCarro marcaCarro);

        Task<MarcaCarro> AlterarAsync(MarcaCarro marcaCarro);

        Task<MarcaCarro> DeletarAsync(MarcaCarro marcaCarro);
    }
}
