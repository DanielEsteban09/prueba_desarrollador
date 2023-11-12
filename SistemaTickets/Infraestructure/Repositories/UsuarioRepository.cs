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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaTicketContext _ticketContext;

        public UsuarioRepository(SistemaTicketContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public async Task<IEnumerable<Respuesta>> AddUsuario(UsuarioDTO usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "CREAR"),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Cedula", usuario.Cedula)
                };

                string sql = $"dbo.Sp_Usuario @opc = @opc, @Nombre = @Nombre, @Cedula = @Cedula";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> DeleteUsuario(int id)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ELIMINAR"),
                    new SqlParameter("@Id", id)
                };

                string sql = $"dbo.Sp_Usuario @opc = @opc, @Id = @Id";
                var response = await _ticketContext.Respuesta.FromSqlRaw(sql, parameters : parameters).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "LISTAR")
                };

                string sql = $"dbo.Sp_Usuario @opc = @opc";
                var response = await _ticketContext.Usuarios.FromSqlRaw(sql, parameters: parameters).ToListAsync();
                return response;
            }
            catch(Exception ex)
            {
                throw new BusinessException($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDTO usuario)
        {
            try
            {
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@opc", "ACTUALIZAR"),
                    new SqlParameter("@Id", usuario.Id),
                    new SqlParameter("@Nombre", usuario.Nombre),
                    new SqlParameter("@Cedula", usuario.Cedula)
                };

                string sql = $"dbo.Sp_Usuario @opc = @opc, @Id = @Id, @Nombre = @Nombre, @Cedula = @Cedula";
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
