using System;
using System.Collections.Generic;
using System.Text;
using UserInfo.Domain.Entities.Shared;
using UserInfo.Domain.Enum;

namespace UserInfo.Domain.Entities
{
    public class Users : EntityIdentity<int>
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public UserType UserType { get; set; }
        public bool Active { get; set; }
    }
}
