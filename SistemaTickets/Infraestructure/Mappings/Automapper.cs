using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Mappings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<EstadoTicket, EstadoTicketDTO>();
            CreateMap<AsignadoUsuario, AsignadoUsuarioDTO>();
        }
    }
}
