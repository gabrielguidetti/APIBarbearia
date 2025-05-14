using Barbearia.API.Data;
using Barbearia.API.Dto;
using Barbearia.API.Models;
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

        /*
        json para enviar nesse endpoint
        {
            "id": 0,
            "nome": "string",
            "senha": "string",
            "email": "string",
            "telefone": "string",
            "dataCadastro": "2025-05-14"
        }
        */
        [HttpPost("AdicionarUsuario")]
        public IActionResult Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            var result = new UsuarioDto()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome,
                DataCadastro = usuario.DataCadastro,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone
            };

            return Ok(result);
        }
    }
}
