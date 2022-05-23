using App.Carros.Domain.Entidades;
using App.Carros.Domain.Interfaces;
using App.Carros.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;


namespace App.Carros.Infra.Data.Repositorio
{
    public class DirecaoCarroRepositorio : IDirecaoCarroRepositorio
    {
        private AppDbContexto _appDbContexto;
        public DirecaoCarroRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<DirecaoCarro> AlterarAsync(DirecaoCarro direcaoCarro)
        {
            _appDbContexto.Update(direcaoCarro);
            await _appDbContexto.SaveChangesAsync();
            return direcaoCarro;
        }

        public async Task<DirecaoCarro> CriarAsync(DirecaoCarro direcaoCarro)
        {
            _appDbContexto.Add(direcaoCarro);
            await _appDbContexto.SaveChangesAsync();
            return direcaoCarro;
        }

        public async Task<DirecaoCarro> DeletarAsync(DirecaoCarro direcaoCarro)
        {
            _appDbContexto.Remove(direcaoCarro);
            await _appDbContexto.SaveChangesAsync();
            return direcaoCarro;
        }

        public async Task<IEnumerable<DirecaoCarro>> GetDirecaoCarrosAsync()
        {
            var result = await _appDbContexto.DirecaoCarros.ToListAsync();
            return result;
        }

        public async Task<DirecaoCarro> GetDirecaoCarroPeloIdAsync(int? id)
        {
            var result = await _appDbContexto.DirecaoCarros.FindAsync(id);
            return result;
        }
    }
}
