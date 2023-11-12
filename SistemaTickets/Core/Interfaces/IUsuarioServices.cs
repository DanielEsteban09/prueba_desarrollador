using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<IEnumerable<Respuesta>> AddUsuario(UsuarioDTO usuario);
        Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDTO usuario);
        Task<IEnumerable<Respuesta>> DeleteUsuario(int id);
    }
}