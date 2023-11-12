using System;
using System.Collections.Generic;

namespace Core.DTOs;

public partial class AsignadoUsuarioDTO
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTicket { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdEstado { get; set; }

    //public virtual EstadoTicketDTO? IdEstadoNavigation { get; set; }

    //public virtual TicketDTO? IdTicketNavigation { get; set; }

    //public virtual UsuarioDTO? IdUsuarioNavigation { get; set; }
}
