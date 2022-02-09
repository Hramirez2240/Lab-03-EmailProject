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
    public interface IEmployeeService : IBaseService<Employee, EmployeeDto>
    {
       
    }

    public class EmployeeService : BaseService<Employee, EmployeeDto>, IEmployeeService
    {
        public EmployeeService(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
   
        }

        public override async Task<EmployeeDto> Edit(int id, EmployeeDto dto)
        {
            string newBossMail, oldBossMail, employeeName, newBossName;

            var entity = await _dbset.FindAsync(id);

            oldBossMail = BossDataService.GetBossData(_context, entity).Email;

            if (entity == null)
            {
                return null;
            }

            entity = _mapper.Map(dto, entity);

            _dbset.Update(entity);

            await _context.SaveChangesAsync();

            employeeName = entity.Name + " " + entity.LastName;

            newBossName = BossDataService.GetBossData(_context, entity).Name + " " + BossDataService.GetBossData(_context, entity).LastName;

            newBossMail = BossDataService.GetBossData(_context, entity).Email;

            EmailService.CreateMessage(oldBossMail, newBossMail, employeeName, newBossName);

            return _mapper.Map(entity, dto);
        }
    }
}
