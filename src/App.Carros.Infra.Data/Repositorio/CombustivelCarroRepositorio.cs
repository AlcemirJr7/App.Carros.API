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
    public class CombustivelCarroRepositorio : ICombustivelCarroRepositorio
    {
        private AppDbContexto _appDbContexto;
        public CombustivelCarroRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<CombustivelCarro> AlterarAsync(CombustivelCarro combustivelCarro)
        {
            _appDbContexto.Update(combustivelCarro);
            await _appDbContexto.SaveChangesAsync();
            return combustivelCarro;
        }

        public async Task<CombustivelCarro> CriarAsync(CombustivelCarro combustivelCarro)
        {
            _appDbContexto.Add(combustivelCarro);
            await _appDbContexto.SaveChangesAsync();
            return combustivelCarro;
        }

        public async Task<CombustivelCarro> DeletarAsync(CombustivelCarro combustivelCarro)
        {
            _appDbContexto.Remove(combustivelCarro);
            await _appDbContexto.SaveChangesAsync();
            return combustivelCarro;
        }

        public async Task<IEnumerable<CombustivelCarro>> GetCombustiveisCarroAsync()
        {
            var result = await _appDbContexto.CombustivelCarros.ToListAsync();
            return result;
        }

        public async Task<CombustivelCarro> GetCombustivelCarroPeloIdAsync(int? id)
        {
            var result = await _appDbContexto.CombustivelCarros.FindAsync(id);
            return result;
        }
    }
}
