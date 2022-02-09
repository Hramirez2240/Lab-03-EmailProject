using AutoMapper;
using EmailBossProject.Bl.Dto;
using EmailBossProject.Model.Context;
using EmailBossProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Services
{
    public interface IBossService : IBaseService<Boss, BossDto>
    {

    }

    public class BossService : BaseService<Boss, BossDto>, IBossService
    {
        public BossService(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
