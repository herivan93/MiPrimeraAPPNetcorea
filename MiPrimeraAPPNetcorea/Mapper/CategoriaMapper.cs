using AutoMapper;
using MiPrimeraAPPNetcorea.DTO;
using MiPrimeraAPPNetcorea.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPNetcorea.Mapper
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
