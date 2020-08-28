using AutoMapper;
using MiPrimeraAPPCORE.DTO;
using MiPrimeraAPPCORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Mapper
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
