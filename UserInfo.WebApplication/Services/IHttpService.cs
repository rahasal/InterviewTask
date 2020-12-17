using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserInfo.Application.Common.Models;
using UserInfo.Application.Dto;
using UserInfo.Domain.Entities;

namespace UserInfo.Application.Services
{
    public interface IHttpService
    {
        Task<TodoItemDto> GetJsonAsync(string url);
    }
}
