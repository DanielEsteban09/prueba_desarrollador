using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class TicketServices : ITicketServices
    {
        private ITicketRepository _ticketRepository;

        public TicketServices(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<IEnumerable<Respuesta>> AddTicket(TicketDTO ticket)
        {
            var addTicket = _ticketRepository.AddTicket(ticket);
            return addTicket;
        }

        public Task<IEnumerable<Respuesta>> DeleteTicket(int id)
        {
            var deleteUsuario = _ticketRepository.DeleteTicket(id);
            return deleteUsuario;
        }

        public Task<IEnumerable<Ticket>> GetTickets()
        {
            var getUsuarios = _ticketRepository.GetTickets();
            return getUsuarios;
        }

        public Task<IEnumerable<Respuesta>> UpdateTicket(TicketDTO ticket)
        {
            var updateTicket = _ticketRepository.UpdateTicket(ticket);
            return updateTicket;
        }
    }
}
