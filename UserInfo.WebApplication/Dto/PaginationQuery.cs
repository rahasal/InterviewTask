using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.Dto
{
    public class PaginationQuery
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
