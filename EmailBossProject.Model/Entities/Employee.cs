using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Model.Entities
{
    public class Employee : BaseEntity
    {
        public decimal Salary { get; set; }
        public int BossId { get; set; }
    }
}
