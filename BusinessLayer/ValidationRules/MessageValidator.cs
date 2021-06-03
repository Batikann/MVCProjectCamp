using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Kısmı Boş Geçilemez");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Maili Boş Geçilemez");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 Karakterden Fazla Karakter Girişi Yapmayın");
        }
    }
}
