using App.Carros.Domain.Entidades;
using CleanArchMvc.Infra.Data.Indentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Carros.Infra.Data.Contexto
{
    public class AppDbContexto : IdentityDbContext<AppUser>
    {
        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
        {

        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<CambioCarro> CambioCarros { get; set; }
        public DbSet<CombustivelCarro> CombustivelCarros { get; set; }
        public DbSet<DirecaoCarro> DirecaoCarros { get; set; }
        public DbSet<MarcaCarro> MarcaCarros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContexto).Assembly);

        }
    }
}
