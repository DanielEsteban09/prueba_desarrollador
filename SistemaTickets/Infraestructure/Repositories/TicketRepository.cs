using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Infraestructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SistemaTicketContext _ticketContext;

        public TicketRepository(SistemaTicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<IEnumerable<Respuesta>> AddTicket(TicketDTO ticket)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "CREAR"),
                    new SqlParameter("@Descripcion", ticket.Descripcion),
                    new SqlParameter("@Numero", ticket.Numero),
                    new SqlParameter("@Prioridad", ticket.Prioridad)
                };

                string sql = $"dbo.Sp_Tickets @opc = @opc, @Descripcion = @Descripcion, @Numero = @Numero, @Prioridad = @Prioridad";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteTicket(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@Id", id)
                };

                string sql = $"dbo.Sp_Tickets @opc = @opc, @Id = @Id";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"dbo.Sp_Tickets @opc = @opc";
                var response = await _ticketContext.Tickets.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> UpdateTicket(TicketDTO ticket)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@Id", ticket.Id),
                    new SqlParameter("@Descripcion", ticket.Descripcion),
                    new SqlParameter("@Numero", ticket.Numero),
                    new SqlParameter("@Prioridad", ticket.Prioridad)
                };

                string sql = $"dbo.Sp_Tickets @opc = @opc, @Id = @Id, @Descripcion = @Descripcion, @Numero = @Numero, @Prioridad = @Prioridad";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch(Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}
