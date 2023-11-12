using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? Numero { get; set; }

    public string? Prioridad { get; set; }

    public virtual ICollection<AsignadoUsuario> AsignadoUsuarios { get; set; } = new List<AsignadoUsuario>();
}
