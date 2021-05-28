using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova.Core.EF.Configurations
{
    public class OrdineConfig : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.DataOrdine)
                .IsRequired();

            builder
                .Property(o => o.CodiceOrdine)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(o => o.CodiceProdotto)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(o => o.Importo)
                .IsRequired();

            builder
                .HasOne(c => c.Cliente)
                .WithMany(o => o.Ordini)
                .HasForeignKey(o => o.ClienteId);
                







        }
    }
}
