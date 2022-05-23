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
    public class DirecaoCarroConfiguracao : IEntityTypeConfiguration<DirecaoCarro>
    {
        public void Configure(EntityTypeBuilder<DirecaoCarro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new DirecaoCarro(1, "Normal"),
                            new DirecaoCarro(2, "Hidraulica"),
                            new DirecaoCarro(3, "Eletrica"));

        }
    }
}
