using FluentValidation;
using jwtProject.Entities.Dtos.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtProject.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator:AbstractValidator<ProductAddDto> 
    {
        public ProductAddDtoValidator()
        {
            RuleFor(I => I.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
        }
    }
}
