using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.Common.FluentValidation
{
    public class UsersValidator : AbstractValidator<UsersDto>
    {
        public UsersValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("لطفا ایمیل را وارد نمایید");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفا نام را وارد نمایید");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفا نام خانوادگی را وارد نمایید");
        }
    }
}
