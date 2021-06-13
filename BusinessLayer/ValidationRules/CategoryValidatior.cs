using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior: AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş keçəməzsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıqlamanı boş keçəməzsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Ən az 3 hərif yazın");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("20 hərifdən çox giriş etməyin");
        }
    }
}
