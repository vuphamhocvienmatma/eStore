using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yêu cầu nhập họ")
                .MaximumLength(200).WithMessage("Không quá 200 kí tự");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yêu cầu nhập tên riêng")
                .MaximumLength(200).WithMessage("Không quá 200 kí tự");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Yêu cầu nhập đúng ngày sinh");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Yêu cầu nhập Email")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Nhập đúng dạng Email");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Yêu cầu số điện thoại");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yêu cầu nhập tên người dùng");

            RuleFor(x => x.Password).MinimumLength(5).WithMessage("Nhập ít nhất 5 kí tự")
                .NotEmpty().WithMessage("Nhập mật khẩu")
                .MaximumLength(200).WithMessage("Nhập không quá 200 kí tự")
                .Matches(@"[A-Z]+").WithMessage("Mật khẩu phải có ít nhát một kí tự in hoa")
                .Matches(@"[a-z]+").WithMessage("Mật khẩu phải có ít nhát một kí tự thường")
                .Matches(@"[0-9]+").WithMessage("Mật khẩu phải có ít nhất một số");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Yêu cầu nhập lại mật khẩu");
                }
            });
        }
    }
}