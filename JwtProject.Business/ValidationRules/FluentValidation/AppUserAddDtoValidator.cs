using FluentValidation;
using jwtProject.Entities.Dtos.AppUserDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(I => I.FullName).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
        }
    }
}
