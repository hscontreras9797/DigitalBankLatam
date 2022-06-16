using Digital.Bank.Latam.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.EntityFramework.Configurations
{
    public static class UsuariosConfiguration
    {
        public static void Configuration(this EntityTypeBuilder<Usuarios> entity)
        {
            entity.ToTable("Usuarios");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).HasColumnType("varchar(100)").IsRequired();
            entity.Property(x => x.Fecha_Nacimiento).HasColumnType("varchar(50)").IsRequired();
            entity.Property(x => x.Sexo).HasColumnType("varchar(1)").IsRequired();
        }
    }
}
