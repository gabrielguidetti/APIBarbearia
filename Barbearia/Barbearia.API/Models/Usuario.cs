using System;
using System.Collections.Generic;

namespace Barbearia.API.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Senha { get; set; }

    public string? Email { get; set; }

    public string? Telefone { get; set; }

    public DateOnly? DataCadastro { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; }

    public Usuario()
    {
        Agendamentos = new List<Agendamento>();
    }
}
