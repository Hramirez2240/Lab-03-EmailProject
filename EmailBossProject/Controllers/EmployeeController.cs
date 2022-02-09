using EmailBossProject.Bl.Dto;
using EmailBossProject.Model.Entities;
using EmailBossProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailBossProject.Api.Controllers
{
    public class EmployeeController : BaseController<Employee, EmployeeDto>
    {
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {

        }
    }
}
