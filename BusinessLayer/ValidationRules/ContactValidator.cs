using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email Alanını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 karakter girebilirsiniz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
        }
    }
}
