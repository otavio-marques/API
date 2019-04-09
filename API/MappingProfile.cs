using AutoMapper;
using Data.Entities;
using Service.Dtos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cliente
            CreateMap<ClienteData, Cliente>();
            CreateMap<Cliente, ClienteData>();
        }
    }
}
