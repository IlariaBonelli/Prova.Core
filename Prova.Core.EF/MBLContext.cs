using System;
using System.Collections.Generic;
using System.Text;
using Prova.Core.EF.Configurations;
using Prova.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Prova.Core.EF
{
    public class MBLContext: DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }

        public MBLContext() : base() { }

        public MBLContext(DbContextOptions<MBLContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = GestoreDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                options.UseSqlServer(connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfig());
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfig());
        }



    }
}
