using App.Carros.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Infra.Data.ConfiguracaoEntidades
{
    public class CarroConfiguracao : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preco).HasPrecision(10, 2);

            builder.HasOne(e => e.Cambio).WithMany(e => e.Carros)
                .HasForeignKey(e => e.CambioId);

            builder.HasOne(e => e.Combustivel).WithMany(e => e.Carros)
                .HasForeignKey(e => e.CombustivelId);

            builder.HasOne(e => e.Direcao).WithMany(e => e.Carros)
                .HasForeignKey(e => e.DirecaoId);

            builder.HasOne(e => e.Marca).WithMany(e => e.Carros)
                .HasForeignKey(e => e.MarcaId);
        }
    }
}
