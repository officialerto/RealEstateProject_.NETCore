using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImagesValidation : AbstractValidator<Images>
    {
        public ImagesValidation()
        {
            RuleFor(x=>x.ImageName).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x=>x.AdvertId).NotEmpty().WithMessage("İlan bilgisi boş bırakılamaz!");
        }
    }
}
