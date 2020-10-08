using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Nhập thông tin đăng nhập");
            RuleFor(x => x.Passwrod).MinimumLength(5).WithMessage("Nhập ít nhất 5 kí tự")
                .NotEmpty().WithMessage("Nhập mật khẩu")
                .MaximumLength(20).WithMessage("Nhập không quá 20 kí tự")
                .Matches(@"[A-Z]+").WithMessage("Mật khẩu phải có ít nhát một kí tự in hoa")
                .Matches(@"[a-z]+").WithMessage("Mật khẩu phải có ít nhát một kí tự thường")
                .Matches(@"[0-9]+").WithMessage("Mật khẩu phải có ít nhất một số");
        }
    }
}