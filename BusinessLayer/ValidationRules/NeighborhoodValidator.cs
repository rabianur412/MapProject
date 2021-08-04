using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NeighborhoodValidator:AbstractValidator<Neighborhood>
    {
        public NeighborhoodValidator()
        {
            RuleFor(x => x.NeighborhoodCoordinate).NotEmpty().WithMessage("Koordinat alanı boş bırakılamaz.");
            RuleFor(x => x.NeighborhoodName).NotEmpty().WithMessage("Mahalle adını boş bırakamazsınız.");
           
          
        }
    }
}
