using API.Responses;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _services;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var response = await _services.GetUsuarios();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioDTO usuarios)
        {
            var usuario = await _services.AddUsuario(usuarios);
            var usuariosDTO = _mapper.Map<IEnumerable<Respuesta>>(usuario);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuariosDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(UsuarioDTO usuarios)
        {
            var usuario = await _services.UpdateUsuario(usuarios);
            var usuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(usuario);
            var respose = new ApiResponse<IEnumerable<Respuesta>>(usuarioDTO);
            return Ok(respose);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await _services.DeleteUsuario(id);
            var usuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(usuario);
            var response = new ApiResponse<IEnumerable<Respuesta>>(usuarioDTO);
            return Ok(response);
        }
    }
}
