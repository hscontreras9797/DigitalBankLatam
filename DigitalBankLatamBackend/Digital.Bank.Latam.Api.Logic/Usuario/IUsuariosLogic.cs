using Digital.Bank.latam.Api.Data.Transfer.Object;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.Logic
{
    public interface IUsuariosLogic
    {
        Task<List<UsuariosDto>> GetUsuariosAsync(bool state);
        Task<UsuariosDto> CreateAsync(UsuariosDto data);
        Task<bool> UpdateAsync(int id, UsuariosDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<UsuariosDto>> ExportarAsync();
    }
}
