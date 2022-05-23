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
    public class MarcaCarroRepositorio : IMarcaCarroRepositorio
    {
        private AppDbContexto _appDbContexto;
        public MarcaCarroRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<MarcaCarro> AlterarAsync(MarcaCarro marcaCarro)
        {
            _appDbContexto.Update(marcaCarro);
            await _appDbContexto.SaveChangesAsync();
            return marcaCarro;
        }

        public async Task<MarcaCarro> CriarAsync(MarcaCarro marcaCarro)
        {
            _appDbContexto.Add(marcaCarro);
            await _appDbContexto.SaveChangesAsync();
            return marcaCarro;
        }

        public async Task<MarcaCarro> DeletarAsync(MarcaCarro marcaCarro)
        {
            _appDbContexto.Remove(marcaCarro);
            await _appDbContexto.SaveChangesAsync();
            return marcaCarro;
        }

        public async Task<IEnumerable<MarcaCarro>> GetMarcaCarroAsync()
        {
            var result = await _appDbContexto.MarcaCarros.ToListAsync();
            return result;
        }

        public async Task<MarcaCarro> GetMarcaCarroPeloIdAsync(int? id)
        {
            var result = await _appDbContexto.MarcaCarros.FindAsync(id);
            return result;
        }
    }
}
