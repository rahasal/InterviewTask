using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Domain.Entities;
using UserInfo.Infrastructure.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using UserInfo.Application.Common.Mapping;
using UserInfo.Application.Dto;
using Microsoft.AspNetCore.Mvc;
using UserInfo.Application.Common.Models;

namespace UserInfo.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserInfoDbContext _userInfoDbContext;
        private readonly IMapper _mapper;
        public UsersService(IUserInfoDbContext userInfoDbContext,IMapper mapper)
        {
            _userInfoDbContext = userInfoDbContext;
            _mapper = mapper;
        }
        public async Task<int> AddAsync(UsersDto dto)
        {
            var model= _mapper.Map<Users>(dto);
            _userInfoDbContext.Users.Add(model);

            await _userInfoDbContext.SaveChangesAsync();

            return model.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var model = new Users { Id = id };
            _userInfoDbContext.Users.Remove(model);

            await _userInfoDbContext.SaveChangesAsync();
        }

        public async Task<PaginatedList<UsersDto>> GetAsync([FromQuery]PaginationQuery query)
        {
            query.PageNumber = query.PageNumber == 0 ? 1 : query.PageNumber;

           return await _userInfoDbContext.Users
                .ProjectTo<UsersDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(query.PageNumber, query.PageSize);
        }

        public async Task<UsersDto> GetAsyncById(int id)
        {
           var model= await  _userInfoDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            return _mapper.Map<UsersDto>(model);
        }

        public async Task UpdateAsync(UsersDto dto)
        {
            var model = _mapper.Map<Users>(dto);
            _userInfoDbContext.Users.Update(model);

            await _userInfoDbContext.SaveChangesAsync();
        }
    }
}
