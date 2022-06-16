using Digital.Bank.Latam.Api.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.Abstractions
{
    public interface IUsuariosRepository
    {
        Task<List<Usuarios>> GetUsuariosAsync(bool state);
        Task<int> CreateAsync(Usuarios data);
        Task<bool> UpdateAsync(int id, Usuarios data);
        Task<bool> DeleteAsync(int id);
        Task<List<Usuarios>> ExportarAsync();
    }
}
