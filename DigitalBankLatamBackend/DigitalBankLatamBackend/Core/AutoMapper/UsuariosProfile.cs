using AutoMapper;
using Digital.Bank.latam.Api.Data.Transfer.Object;
using Digital.Bank.Latam.Api.Entities;

namespace DigitalBankLatamBackend.Core.AutoMapper
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            base.CreateMap<UsuariosDto, Usuarios>().ReverseMap();
        }
    }
}
