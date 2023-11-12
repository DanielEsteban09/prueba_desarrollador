using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public virtual ICollection<AsignadoUsuario> AsignadoUsuarios { get; set; } = new List<AsignadoUsuario>();
}
