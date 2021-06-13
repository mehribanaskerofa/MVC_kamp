using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior : AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş keçməyin");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar soyadını boş keçməyin");
          //  RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Haqqımızda hissəni boş keçməyin");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Ən az 2 hərif yazın");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("50 hərifdən çox giriş etməyin");
          //  RuleFor(x => x.WriterTitle).NotNull().WithMessage("Titleni boş keçməyin");

        }
    {
    }
}
