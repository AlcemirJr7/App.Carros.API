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
    public class CambioCarroRepositorio : ICambioCarroRepositorio
    {
        private AppDbContexto _appDbContexto;
        public CambioCarroRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<CambioCarro> AlterarAsync(CambioCarro cambioCarro)
        {
            _appDbContexto.CambioCarros.Update(cambioCarro);
            await _appDbContexto.SaveChangesAsync();    
            return cambioCarro; 
        }

        public async Task<CambioCarro> CriarAsync(CambioCarro cambioCarro)
        {
            _appDbContexto.Add(cambioCarro);
            await _appDbContexto.SaveChangesAsync();
            return cambioCarro;
        }

        public async Task<CambioCarro> DeletarAsync(CambioCarro cambioCarro)
        {
            _appDbContexto.Remove(cambioCarro);
            await _appDbContexto.SaveChangesAsync();
            return cambioCarro;

        }

        public async Task<IEnumerable<CambioCarro>> GetCambioCarrosAsync()
        {
            var result = await _appDbContexto.CambioCarros.ToListAsync();
            return result;
        }

        public async Task<CambioCarro> GetCambioCarroPeloIdAsync(int? id)
        {
            var result = await _appDbContexto.CambioCarros.FindAsync(id);
            return result;
        }
    }
}
