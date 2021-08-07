using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş keçməyin");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mövzu adını boş keçməyin");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adını boş keçməyin");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Ən az 3 hərif yazın");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Ən az 3 hərif yazın");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50 hərifdən çox giriş etməyin");
        }
    }
}
