using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NeighborhoodValidation : AbstractValidator<Neighborhood>
    {
        public NeighborhoodValidation() 
        {
            RuleFor(x=>x.NeighborhoodName).NotEmpty().WithMessage("Boş bırakılamaz!");
            RuleFor(x=>x.DistrictId).NotEmpty().WithMessage("Semt bilgisi boş bırakılamaz!");
        }
    }
}
