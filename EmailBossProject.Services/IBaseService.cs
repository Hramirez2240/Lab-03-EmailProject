using EmailBossProject.Bl.Dto;
using EmailBossProject.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Services
{
    public interface IBaseService<T, TDto> where T : IBaseEntity where TDto : BaseDto
    {
        Task<List<T>> Get();
        public Task<TDto> Get(int id);

        public Task<TDto> Create(TDto dto);

        public Task<TDto> Edit(int id, TDto dto);

        public Task<IActionResult> Delete(int id);
    }
}
