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
    public class BossDataService
    {
        public static Boss GetBossData(IApplicationDbContext _context, Employee entity)
        {
            return _context.GetDbSet<Boss>().Find(entity.BossId);
        } 
    }
}
