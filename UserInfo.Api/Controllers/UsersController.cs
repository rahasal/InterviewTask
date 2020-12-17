using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserInfo.Application;
using UserInfo.Application.Common.Models;
using UserInfo.Application.Dto;
using UserInfo.Application.Services;
using UserInfo.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserInfo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        // GET: users/
        [HttpGet]
        public async Task<ActionResult<PaginatedList<UsersDto>>> Get([FromQuery] PaginationQuery query)
        {
          var list= await  _usersService.GetAsync(query);

          return list;
        }

        // GET users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDto>> Get(int id)
        {
            if (id ==0)
            {
                return BadRequest();
            }
            return await _usersService.GetAsyncById(id);
        }

        // POST users
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] UsersDto dto)
        {
           return await _usersService.AddAsync(dto);
        }

        // PUT users
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsersDto dto)
        {

            await _usersService.UpdateAsync(dto);
            return NoContent();
        }

        // DELETE users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _usersService.DeleteAsync(id);

            return NoContent();
        }
    }
}
