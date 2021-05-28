using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Core.Model;

namespace Prova.Core.EF.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CodiceCliente)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(c => c.Nome)
                .IsRequired();

            builder
                .Property(c => c.Cognome)
                .IsRequired();







        }
    }
}
