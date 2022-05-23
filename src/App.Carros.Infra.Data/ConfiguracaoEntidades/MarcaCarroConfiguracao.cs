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
    public class MarcaCarroConfiguracao : IEntityTypeConfiguration<MarcaCarro>
    {
        public void Configure(EntityTypeBuilder<MarcaCarro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new MarcaCarro(1, "Volkswagen"),
                            new MarcaCarro(2, "Toyota"),
                            new MarcaCarro(3, "Renault"),
                            new MarcaCarro(4, "Mitsubishi"),
                            new MarcaCarro(5, "Hyundai"),
                            new MarcaCarro(6, "Honda"),
                            new MarcaCarro(7, "Ford"),
                            new MarcaCarro(8, "Fiat"),
                            new MarcaCarro(9, "Chevrolet"),
                            new MarcaCarro(10, "Audi"),
                            new MarcaCarro(11, "BMW"));

        }
    }
}
