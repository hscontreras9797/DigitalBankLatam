using Digital.Bank.latam.Api.Data.Transfer.Object;
using Digital.Bank.Latam.Api.Logic;
using Digital.Bank.Latam.Api.Logic.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;

namespace DigitalBankLatamBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosLogic logic;
        private readonly IJwtAuthenticationService _authService;
        public UsuariosController(IUsuariosLogic logic, IJwtAuthenticationService authService)
        {
            this.logic = logic;
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetBySet(bool state)
        {
            var data = await this.logic.GetUsuariosAsync(state);

            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuariosDto data)
        {
            var dto = await this.logic.CreateAsync(data);

            return Ok(dto);
        }
        [AllowAnonymous]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuariosDto data)
        {
            if (id < 0)
                return NotFound("Id Invalid");

            var success = await this.logic.UpdateAsync(id, data);

            return Ok(success);
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
                return NotFound("Id Invalid");

            var success = await this.logic.DeleteAsync(id);

            return Ok(success);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Exportar()
        {
            DataTable dt = new DataTable();

            var bd = await this.logic.ExportarAsync();

           return Ok(bd);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthDto user)
        {
            var token = _authService.Authenticate(user.Username, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
