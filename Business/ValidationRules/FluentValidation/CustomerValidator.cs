using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage("Lütfen geçerli bir isim giriniz");
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.UserId).NotEqual(c => c.UserId).WithMessage("Kullanmak istediğiniz id numarası zaten kullanılmış");
        }
    }
}
