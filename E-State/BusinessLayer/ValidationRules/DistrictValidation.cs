using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DistrictValidation : AbstractValidator<District>
    {
        public DistrictValidation()
        {
            RuleFor(x => x.DistrictName).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x => x.CityId).NotEmpty().WithMessage("Şehir boş bırakılamaz!");
        }

    }
}
