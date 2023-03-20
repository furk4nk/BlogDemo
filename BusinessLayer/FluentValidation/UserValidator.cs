using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            // NameSurname Rules
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Lütfen İsim Giriniz")
                .MinimumLength(3).WithMessage("İsminizi En az 3 Karakter Olacak Şekilde Giriniz")
                .MaximumLength(30).WithMessage("İsminizi En Fazla 30 Karakter Olacak Şekilde Giriniz");


            // Email Rules
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email Adresi Geçersiz");



            //UserName Rules
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez")
                .MinimumLength(1).WithMessage("Kullanıcı Adı En Az 1 Karakter Olmalı")
                .MaximumLength(50).WithMessage("Kullanıcı Adı En Fazla 50 Karakter Olmalıdır");

        }
    }
}
