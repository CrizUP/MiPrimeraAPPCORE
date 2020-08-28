using MiPrimeraAPPCORE.DTO;
using MiPrimeraAPPCORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MiPrimeraAPPCORE.Mapper
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
