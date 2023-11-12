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
    public class AsignadoUsuarioController : ControllerBase
    {
        private readonly IAsignadoUsuarioServices _services;
        private readonly IMapper _mapper;

        public AsignadoUsuarioController(IAsignadoUsuarioServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var response = await _services.GetAsignadoUsuario();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(AsignadoUsuarioDTO asignadoUsuarios)
        {
            var asignadoUsuario = await _services.AddAsignadoUsuario(asignadoUsuarios);
            var asignadoUsuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(asignadoUsuario);
            var response = new ApiResponse<IEnumerable<Respuesta>>(asignadoUsuarioDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(AsignadoUsuarioDTO asignadoUsuarios)
        {
            var asignadoUsuario = await _services.UpdateAsignadoUsuario(asignadoUsuarios);
            var asignadoUsuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(asignadoUsuario);
            var response = new ApiResponse<IEnumerable<Respuesta>>(asignadoUsuarioDTO);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var asignadoUsuario = await _services.DeleteAsignadoUsuario(id);
            var asignadoUsuarioDTO = _mapper.Map<IEnumerable<Respuesta>>(asignadoUsuario);
            var response = new ApiResponse<IEnumerable<Respuesta>>(asignadoUsuarioDTO);
            return Ok(response);
        }
    }
}
