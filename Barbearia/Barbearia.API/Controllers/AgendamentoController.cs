using Barbearia.API.Data;
using Barbearia.API.Models;
using Barbearia.API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Barbearia.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly BarbeariaContext _context;

        public AgendamentoController(BarbeariaContext context)
        {
            _context = context;
        }

        [HttpPost("MarcarAgendamento")]
        public IActionResult MarcarAgendamento(AgendamentoViewModel model)
        {
            var dataAgendamento = DateOnly.FromDateTime((DateTime)model.DataAgendamento);
            var horaAgemdamento = TimeOnly.FromDateTime((DateTime)model.DataAgendamento);

            var agendamento = new Agendamento()
            {
                UsuarioId = model.UsuarioId,
                BarbeiroId = model.BarbeiroId,
                FilialId = model.FilialId,
                DataAgendamento = dataAgendamento,
                HoraAgendamento = horaAgemdamento,
                Servico = model.Servico
            };

            _context.Agendamentos.Add(agendamento);
            _context.SaveChanges();

            return Ok(agendamento);
        }
    }
}
