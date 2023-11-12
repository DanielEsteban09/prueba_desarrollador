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
    public class TicketController : ControllerBase
    {
        private readonly ITicketServices _services;
        private readonly IMapper _mapper;

        public TicketController(ITicketServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var response = await _services.GetTickets();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TicketDTO tickets)
        {
            var ticket = await _services.AddTicket(tickets);
            var ticketDTO = _mapper.Map<IEnumerable<Respuesta>>(ticket);
            var response = new ApiResponse<IEnumerable<Respuesta>>(ticketDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(TicketDTO tickets)
        {
            var ticket = await _services.UpdateTicket(tickets);
            var ticketDTO = _mapper.Map<IEnumerable<Respuesta>>(ticket);
            var response = new ApiResponse<IEnumerable<Respuesta>>(ticketDTO);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var ticket = await _services.DeleteTicket(id);
            var ticketDTO = _mapper.Map<IEnumerable<Respuesta>>(ticket);
            var response = new ApiResponse<IEnumerable<Respuesta>>(ticketDTO);
            return Ok(response);
        }
    }
}
