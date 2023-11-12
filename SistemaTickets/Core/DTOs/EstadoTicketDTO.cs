using System;
using System.Collections.Generic;

namespace Core.DTOs;

public partial class EstadoTicketDTO
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<AsignadoUsuarioDTO> AsignadoUsuarios { get; set; } = new List<AsignadoUsuarioDTO>();
}
