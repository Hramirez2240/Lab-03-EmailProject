using EmailBossProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Bl.Dto
{
    public class EmployeeDto : BaseDto
    {
        public decimal Salary { get; set; }
        public int BossId { get; set; }
        public virtual Boss Boss { get; set; }
    }
}
