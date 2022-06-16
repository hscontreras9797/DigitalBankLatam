using Digital.Bank.Latam.Api.Entities;
using Digital.Bank.Latam.Api.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Digital.Bank.Latam.Api.EntityFramework
{
    public class Digital_Bank_LatamContext : DbContext
    {
        public Digital_Bank_LatamContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected Digital_Bank_LatamContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().Configuration();


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
