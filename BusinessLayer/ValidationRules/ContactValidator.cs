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
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsim alanını boş bırakamazsınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapabilirsiniz.");
            RuleFor(x => x.Subject).MinimumLength(50).WithMessage("En fazla 50 karakter girişi yapabilirsiniz.");
            RuleFor(x => x.UserName).MaximumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın.");         
        }
    }
}
