using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITicketServices
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<IEnumerable<Respuesta>> AddTicket(TicketDTO ticket);
        Task<IEnumerable<Respuesta>> UpdateTicket(TicketDTO ticket);
        Task<IEnumerable<Respuesta>> DeleteTicket(int id);
    }
}
