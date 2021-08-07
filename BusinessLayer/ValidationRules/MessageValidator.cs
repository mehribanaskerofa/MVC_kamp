using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Mail adresini boş keçməyin");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mövzu adını boş keçməyin");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş keçməyin");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Mail adresini düzgün qeyd edin");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Ən az 3 hərif yazın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("100 hərifdən çox giriş etməyin");
        }
    }
}
