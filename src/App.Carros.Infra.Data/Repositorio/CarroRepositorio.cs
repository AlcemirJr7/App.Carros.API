using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using App.Carros.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Infra.Data.Repositorio
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private AppDbContexto _appDbContexto;
        public CarroRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }
        public async Task<Carro> AlterarAsync(Carro carro)
        {
            _appDbContexto.Update(carro);
            await _appDbContexto.SaveChangesAsync();
            return carro;
        }

        public async Task<Carro> CriarAsync(Carro carro)
        {
            _appDbContexto.Add(carro);
            await _appDbContexto.SaveChangesAsync();
            return carro;
        }

        public async Task<Carro> DeletarAsync(Carro carro)
        {
            _appDbContexto.Remove(carro);
            await _appDbContexto.SaveChangesAsync();
            return carro;
        }

        public async Task<Carro> GetCarroPeloIdAsync(int? id)
        {
            var result = await _appDbContexto.Carros.FindAsync(id);
            
            return result;
        }

        public async Task<IEnumerable<Carro>> GetCarrosAsync()
        {
            var result = await _appDbContexto.Carros.ToListAsync();
            return result;
        
        }
    }
}
