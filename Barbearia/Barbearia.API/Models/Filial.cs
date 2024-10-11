using System;
using System.Collections.Generic;

namespace Barbearia.API.Models;

public partial class Filial
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Endereco { get; set; }

    public string? Telefone { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; }

    public virtual ICollection<Barbeiro> Barbeiros { get; set; }

    public Filial()
    {
        Agendamentos = new List<Agendamento>();
        Barbeiros = new List<Barbeiro>();
    }
}
