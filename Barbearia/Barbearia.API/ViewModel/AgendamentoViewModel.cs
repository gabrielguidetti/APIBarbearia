namespace Barbearia.API.ViewModel
{
    public class AgendamentoViewModel
    {
        public int? UsuarioId { get; set; }

        public int? BarbeiroId { get; set; }

        public int? FilialId { get; set; }

        public DateTime? DataAgendamento { get; set; }

        public string? Servico { get; set; }
    }
}
