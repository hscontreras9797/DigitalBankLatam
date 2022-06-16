using AutoMapper;
using Digital.Bank.latam.Api.Data.Transfer.Object;
using Digital.Bank.Latam.Api.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Bank.Latam.Api.Logic.Usuario
{
    public class UsuariosLogic : IUsuariosLogic
    {
        private readonly IUsuariosRepository repository;
        private readonly IMapper mapper;

        public UsuariosLogic(IUsuariosRepository clientRepository, IMapper mapper)
        {
            this.repository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<UsuariosDto> CreateAsync(UsuariosDto data)
        {
            var entity = this.mapper.Map<Entities.Usuarios>(data);

            data.Id = await this.repository.CreateAsync(entity);

            return data;
        }

        public Task<bool> DeleteAsync(int id)
        {
            return this.repository.DeleteAsync(id);
        }

        public async Task<List<UsuariosDto>> ExportarAsync()
        {
            var data = await this.repository.ExportarAsync();

            return this.mapper.Map<List<UsuariosDto>>(data);
        }

        public async Task<List<UsuariosDto>> GetUsuariosAsync(bool state)
        {
            var data = await this.repository.GetUsuariosAsync(state);

            return this.mapper.Map<List<UsuariosDto>>(data);
        }

        public Task<bool> UpdateAsync(int id, UsuariosDto data)
        {
            var entity = this.mapper.Map<Entities.Usuarios>(data);

            return this.repository.UpdateAsync(id, entity);
        }
    }
}
