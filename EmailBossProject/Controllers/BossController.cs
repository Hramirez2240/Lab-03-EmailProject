using EmailBossProject.Bl.Dto;
using EmailBossProject.Model.Entities;
using EmailBossProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailBossProject.Api.Controllers
{
    public class BossController : BaseController<Boss, BossDto>
    {
        public BossController(IBossService bossService) : base(bossService)
        {

        }
    }
}
