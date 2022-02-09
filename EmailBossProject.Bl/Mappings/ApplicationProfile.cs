using AutoMapper;
using EmailBossProject.Bl.Dto;
using EmailBossProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Bl.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Boss, BossDto>()
                .ReverseMap();

            CreateMap<Employee, EmployeeDto>()
                .ReverseMap();
        }
    }
}
