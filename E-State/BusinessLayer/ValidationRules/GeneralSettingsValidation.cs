using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GeneralSettingsValidation : AbstractValidator<GeneralSettings>
    {
        public GeneralSettingsValidation() 
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x => x.ImageName).NotEmpty().WithMessage("Boş bırakılamaz!");
        }
    }
}
