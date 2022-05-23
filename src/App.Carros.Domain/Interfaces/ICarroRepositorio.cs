using App.Carros.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Domain.Interfaces
{
    public interface ICarroRepositorio
    {
        Task<IEnumerable<Carro>> GetCarrosAsync();

        Task<Carro> GetCarroPeloIdAsync(int? id);

        Task<Carro> CriarAsync(Carro carro);

        Task<Carro> AlterarAsync(Carro carro);

        Task<Carro> DeletarAsync(Carro carro);


    }
}
