using Barbearia.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly BarbeariaContext _context;

        public UsuarioController(BarbeariaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if(usuario == null)
                return NotFound();

            return Ok(usuario);
        }
    }
}
