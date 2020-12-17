using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInfo.Application.Dto;
using UserInfo.Application.Services;

namespace UserInfo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiVersion("1.1")]
    public class HttpRequestController : ControllerBase
    {
        private readonly IHttpService _httpService;
        public string BaseAddress { get => "https://jsonplaceholder.typicode.com/"; }
        public HttpRequestController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// https://localhost:5001/HttpRequest/4
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<TodoItemDto> Get(int id)
        {
            var url = $"{BaseAddress}todos/{id}";
            return await _httpService.GetJsonAsync(url);
        }

    }
}
