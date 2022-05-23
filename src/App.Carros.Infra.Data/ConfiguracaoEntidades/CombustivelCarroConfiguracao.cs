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
    public class CombustivelCarroConfiguracao : IEntityTypeConfiguration<CombustivelCarro>
    {
        public void Configure(EntityTypeBuilder<CombustivelCarro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new CombustivelCarro(1, "Flex"),
                            new CombustivelCarro(2, "Gasolina"),
                            new CombustivelCarro(3, "Alcool"),
                            new CombustivelCarro(4, "Diesel"));

        }
    }
}
