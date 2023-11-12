using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class AsignadoUsuario
{
    public int Id { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTicket { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdEstado { get; set; }

    public virtual EstadoTicket? IdEstadoNavigation { get; set; }

    public virtual Ticket? IdTicketNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
