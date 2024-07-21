using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CityValidation : AbstractValidator<City>
    {
        public CityValidation()
        {
            RuleFor(x=>x.CityName).NotEmpty().WithMessage("Bu alan boş bırakılamaz!");
            RuleFor(x=>x.CityName).MinimumLength(15).MaximumLength(20);
        }
    }
}
