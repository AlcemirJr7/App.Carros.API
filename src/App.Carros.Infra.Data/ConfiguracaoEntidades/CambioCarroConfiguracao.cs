﻿using App.Carros.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Carros.Infra.Data.ConfiguracaoEntidades
{
    public class CambioCarroConfiguracao : IEntityTypeConfiguration<CambioCarro>
    {
        public void Configure(EntityTypeBuilder<CambioCarro> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new CambioCarro(1, "Manual"),
                            new CambioCarro(2, "Automatico"));
                            
        }
    }
}
