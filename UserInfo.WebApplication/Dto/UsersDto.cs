using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserInfo.Domain.Entities;
using UserInfo.Domain.Enum;

namespace UserInfo.Application
{
    public class UsersDto : BaseDto<Users>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }
        public bool Active { get; set; }
    }
}
