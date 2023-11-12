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
    public class UsuarioServices : IUsuarioServices
    {
        private IUsuarioRepository _repository;

        public UsuarioServices(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Respuesta>> AddUsuario(UsuarioDTO usuario)
        {
            var addUsuario = _repository.AddUsuario(usuario);
            return addUsuario;
        }

        public Task<IEnumerable<Respuesta>> DeleteUsuario(int id)
        {
            var deleteUsuario = _repository.DeleteUsuario(id);
            return deleteUsuario;
        }

        public Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var getUsuarios = _repository.GetUsuarios();
            return getUsuarios;
        }

        public Task<IEnumerable<Respuesta>> UpdateUsuario(UsuarioDTO usuario)
        {
            var updateUsuario = _repository.UpdateUsuario(usuario);
            return updateUsuario;
        }
    }
}
