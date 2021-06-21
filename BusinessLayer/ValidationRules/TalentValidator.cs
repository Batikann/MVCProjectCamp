using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TalentValidator:AbstractValidator<Talent>
    {
        public TalentValidator()
        {
            RuleFor(x => x.TalentName).NotEmpty().WithMessage("Yetenek İsmi Alanı Boş Bırakılmaz");
            RuleFor(x => x.TalentName).MinimumLength(2).WithMessage("Yetenek Adı 2 Karakterden Kısa Olamaz");
            RuleFor(x => x.TalentName).MaximumLength(40).WithMessage("Yetenek Adı 40 Karakterden Uzun Olamaz");
            RuleFor(x => x.Range).NotEmpty().WithMessage("Yetenek Yüzdesi Boş Geçilemez");
        }
    }
}
