using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Application.Common.Models;
using UserInfo.Application.Dto;

namespace UserInfo.Application.Services
{
    public interface IUsersService
    {
        public Task<int> AddAsync(UsersDto dto);

        public Task DeleteAsync(int id);

        public Task<PaginatedList<UsersDto>> GetAsync([FromQuery] PaginationQuery query);

        public Task<UsersDto> GetAsyncById(int id);

        public Task UpdateAsync(UsersDto dto);
    }
}
