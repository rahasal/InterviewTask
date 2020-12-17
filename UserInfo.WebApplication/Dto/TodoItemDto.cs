using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.Dto
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Completed { get; set; }

    }
}
