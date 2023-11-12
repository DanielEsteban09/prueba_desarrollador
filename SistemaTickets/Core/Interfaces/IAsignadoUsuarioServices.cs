using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAsignadoUsuarioServices
    {
        Task<IEnumerable<AsignadoUsuario>> GetAsignadoUsuario();
        Task<IEnumerable<Respuesta>> AddAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario);
        Task<IEnumerable<Respuesta>> UpdateAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario);
        Task<IEnumerable<Respuesta>> DeleteAsignadoUsuario(int id);
    }
}
