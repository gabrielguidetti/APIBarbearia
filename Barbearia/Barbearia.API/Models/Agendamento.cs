using System;
using System.Collections.Generic;

namespace Barbearia.API.Models;

public partial class Agendamento
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? BarbeiroId { get; set; }

    public int? FilialId { get; set; }

    public DateOnly? DataAgendamento { get; set; }

    public TimeOnly? HoraAgendamento { get; set; }

    public string? Servico { get; set; }

    public virtual Barbeiro? Barbeiro { get; set; }

    public virtual Filial? Filial { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
