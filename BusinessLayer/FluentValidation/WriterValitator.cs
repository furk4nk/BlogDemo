using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
	public class WriterValitator : AbstractValidator<Writer>
	{
		public WriterValitator()
		{
			//writer Name rules
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsminizi Giriniz");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen İsminizi en fazla 50 karakter olacak şekilde giriniz");
			RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Lütfen isminizi en az 5 karakter olacak şekilde giriniz");


			// mail rules
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Giriniz");
			RuleFor(x => x.WriterMail).EmailAddress().WithMessage("lütfen geçerli bir email adresi giriniz");



            //writer password rules
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Oluşturmanız Gerekiyor")
				.Matches(@"[A-Z]+").WithMessage("Şifrenizde En Az 1 Büyük Harf Bulunmalıdır")
                .Matches(@"[a-z]+").WithMessage("Şifrenizde En Az 1 Küçük Harf Bulunmalıdır")
                .Matches(@"[0-9]+").WithMessage("Şifrenizde En Az 1 Rakam Bulunmalıdır")
                .Matches(@"[\!\?\*\.]*$+").WithMessage("Şifrenizde En Az 1 Özel Karakter Bulunmalıdır (!? *.).")
                .MinimumLength(8).WithMessage("Şifreniz En Az 8 Karakter Uzunluğunda Olmalıdır")
                .MaximumLength(16).WithMessage("Şifreniz En Fazla 16 Karakter Uzunluğunda Olmalıdır");


			//Writer About rules
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Alanını Doldurunuz")
				.MinimumLength(15).WithMessage("En Az 15 Karakter Girmelisiniz")
				.MaximumLength(5000).WithMessage("En Fazla 5000 Karakter Girmelisiniz");


			//WriterImage rules
			//RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Bir Resim Seçiniz);
		}
	}
}
