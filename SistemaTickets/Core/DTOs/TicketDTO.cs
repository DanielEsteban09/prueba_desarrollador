using System;
using System.Collections.Generic;

namespace Core.DTOs;

public partial class TicketDTO
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public int? Numero { get; set; }

    public string? Prioridad { get; set; }

    //public virtual ICollection<AsignadoUsuarioDTO> AsignadoUsuarios { get; set; } = new List<AsignadoUsuarioDTO>();
}
