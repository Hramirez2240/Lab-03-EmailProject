using EmailBossProject.Bl.Dto;
using EmailBossProject.Core.Model;
using EmailBossProject.Model.Entities;
using EmailBossProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EmailBossProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TDto> : ControllerBase where T : BaseEntity where TDto : BaseDto
    {
        protected readonly IBaseService<T, TDto> _baseService;

        public BaseController(IBaseService<T, TDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var entities = await _baseService.Get();

            return Ok(entities);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var dto = await _baseService.Get(id);

            if (dto is null) return NotFound("Not Found");

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TDto dto)
        {
            var dtoAdded = await _baseService.Create(dto);

            if (dtoAdded is null) return BadRequest();

            return Ok(dtoAdded);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TDto dto)
        {

            var dtoUpdated = await _baseService.Edit(id, dto);

            if (dtoUpdated is null) return NotFound();

            return Ok(dtoUpdated);

        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _baseService.Delete(id);

            return Ok();
        }
    }
}
