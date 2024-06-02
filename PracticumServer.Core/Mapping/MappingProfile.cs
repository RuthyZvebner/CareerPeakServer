using AutoMapper;
using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Worker, WorkerDto>().ReverseMap();
        }
    }
}
