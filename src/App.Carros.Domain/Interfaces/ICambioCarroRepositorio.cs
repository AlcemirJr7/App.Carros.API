using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Interfaces
{
    public  interface ICambioCarroRepositorio
    {
        Task<IEnumerable<CambioCarro>> GetCambioCarrosAsync();

        Task<CambioCarro> GetCambioCarroPeloIdAsync(int? id);

        Task<CambioCarro> CriarAsync(CambioCarro cambioCarro);

        Task<CambioCarro> AlterarAsync(CambioCarro cambioCarro);

        Task<CambioCarro> DeletarAsync(CambioCarro cambioCarro);

    }
}
