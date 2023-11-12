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
    public class AsignadoUsuarioServices : IAsignadoUsuarioServices
    {
        private IAsignadoUsuarioRepository _asignadoUsuarioRepository;

        public AsignadoUsuarioServices(IAsignadoUsuarioRepository asignadoUsuarioRepository)
        {
            _asignadoUsuarioRepository = asignadoUsuarioRepository;
        }

        public Task<IEnumerable<Respuesta>> AddAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario)
        {
            var addAsignadoUsuario = _asignadoUsuarioRepository.AddAsignadoUsuario(asignadoUsuario);
            return addAsignadoUsuario;
        }

        public Task<IEnumerable<Respuesta>> DeleteAsignadoUsuario(int id)
        {
            var deleteAsignadoUsuario = _asignadoUsuarioRepository.DeleteAsignadoUsuario(id);
            return deleteAsignadoUsuario;
        }

        public Task<IEnumerable<AsignadoUsuario>> GetAsignadoUsuario()
        {
            var getAsignadoUsuario = _asignadoUsuarioRepository.GetAsignadoUsuario();
            return getAsignadoUsuario;
        }

        public Task<IEnumerable<Respuesta>> UpdateAsignadoUsuario(AsignadoUsuarioDTO asignadoUsuario)
        {
            var updateAsignadoUsuario = _asignadoUsuarioRepository.UpdateAsignadoUsuario(asignadoUsuario);
            return updateAsignadoUsuario;
        }
    }
}
