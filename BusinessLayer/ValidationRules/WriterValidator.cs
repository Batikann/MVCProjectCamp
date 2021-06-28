using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Alanı Boş Bırakılamaz.");
            //RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında  Alanı Boş Bırakılamaz.");
            //RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan  Alanı Boş Bırakılamaz.");
            //RuleFor(x => x.WriterAbout).Matches("a").WithMessage("Açıklama Kısmında a Harfi Bulunmak Zorunda");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar Adı 2 Karakterden Kısa Olamaz");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar Soyadı 50 Karakterden Uzun Olamaz");
        }
    }
}
