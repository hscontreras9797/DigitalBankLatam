using Digital.Bank.Latam.Api.Abstractions;
using Digital.Bank.Latam.Api.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.EntityFramework.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly Digital_Bank_LatamContext context;
        public UsuariosRepository(Digital_Bank_LatamContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Usuarios data)
        {
            await this.context.AddAsync(data);

            await this.context.SaveChangesAsync();

            return data.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await this.context.Usuarios.FindAsync(id);

            if (data != null)
            {
                this.context.Usuarios.Remove(data);

                return await this.context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<List<Usuarios>> ExportarAsync()
        {
            var data = await this.context.Usuarios.Where(x => x.State == true).ToListAsync();

            //SqlDataAdapter da = new SqlDataAdapter(data);
            return data;
        }

        public async Task<List<Usuarios>> GetUsuariosAsync(bool state)
        {
            var data = await this.context.Usuarios.Where(x => x.State == state).ToListAsync();

            return data;
        }

        public async Task<bool> UpdateAsync(int id, Usuarios data)
        {
            var entity = await this.context.Usuarios.FindAsync(id);

            if (entity != null)
            {
                entity.Name = data.Name;
                entity.Fecha_Nacimiento = data.Fecha_Nacimiento;
                entity.Sexo = data.Sexo;

                this.context.Update(entity);

                return await this.context.SaveChangesAsync() > 0;
            }

            return false;
        }
     }
    }
