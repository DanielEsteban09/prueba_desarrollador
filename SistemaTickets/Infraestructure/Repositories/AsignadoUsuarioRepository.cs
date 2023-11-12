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
    public class AsignadoUsuarioRepository : IAsignadoUsuarioRepository
    {
        private readonly SistemaTicketContext _ticketContext;

        public AsignadoUsuarioRepository(SistemaTicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }

        public async Task<IEnumerable<Respuesta>> AddAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "CREAR"),
                    new SqlParameter("@Id_usuario", asignadoUsuario.IdUsuario),
                    new SqlParameter("@Id_ticket", asignadoUsuario.IdTicket),
                    new SqlParameter("@Id_Estado", asignadoUsuario.IdEstado)
                };

                string sql = $"dbo.Sp_AsignadoUsuario @opc = @opc, @Id_usuario = @Id_usuario, @Id_ticket = @Id_ticket, @Id_Estado = @Id_Estado";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteAsignadoUsuario(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@Id", id)
                };

                string sql = $"dbo.Sp_AsignadoUsuario @opc = @opc, @Id = @Id";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<AsignadoUsuario>> GetAsignadoUsuario()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"dbo.Sp_AsignadoUsuario @opc = @opc";
                var response = await _ticketContext.AsignadoUsuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch(Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> UpdateAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@Id", asignadoUsuario.Id),
                    new SqlParameter("@Id_usuario", asignadoUsuario.IdUsuario),
                    new SqlParameter("@Id_ticket", asignadoUsuario.IdTicket),
                    new SqlParameter("@Id_Estado", asignadoUsuario.IdEstado)
                };

                string sql = $"dbo.Sp_AsignadoUsuario @opc = @opc, @Id = @Id, @Id_usuario = @Id_usuario, @Id_ticket = @Id_ticket, @Id_Estado = @Id_Estado";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }
    }
}
