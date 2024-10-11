using System;
using System.Collections.Generic;

namespace Barbearia.API.Models;

public partial class Barbeiro
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Especialidade { get; set; }

    public int? FilialId { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; }

    public virtual Filial? Filial { get; set; }

    public Barbeiro()
    {
        Agendamentos = new List<Agendamento>();
    }
}
