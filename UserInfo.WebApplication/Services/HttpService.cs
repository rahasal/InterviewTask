using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UserInfo.Application.Common.Models;
using UserInfo.Application.Dto;

namespace UserInfo.Application.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<TodoItemDto> GetJsonAsync(string url)
        {
            var request = CreateRequest(url);
            var result =await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            using (var responseStream = await result.Content.ReadAsStreamAsync())
            {
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                   var _jsonSerializer = new JsonSerializer();
                   return _jsonSerializer.Deserialize<TodoItemDto>(jsonTextReader);
                }
            }
        }

        private static HttpRequestMessage CreateRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Get, url);
        }
    }
}
