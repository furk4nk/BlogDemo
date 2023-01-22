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
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Lütfen İsminizi Giriniz");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen İsminizi en fazla 50 karakter olacak şekilde giriniz");
			RuleFor(x => x.WriterName).MinimumLength(5).WithMessage("Lütfen isminizi en az 5 karakter olacak şekilde giriniz");


			// mail rules
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Giriniz");
			RuleFor(x => x.WriterMail).EmailAddress().WithMessage("lütfen geçerli bir email adresi giriniz");



			// password rules
			RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifrenizde en az bir büyük harf olmalıdır");
			RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifrenizde en az bir küçük harf olmalıdır");
			RuleFor(x => x.WriterPassword).Matches(@"[10-9]+").WithMessage("şifrenizde en az bir rakam olmalıdır");
			//RuleFor(x => x.WriterPassword).Matches(@"[^a-zA-Z0-9_]+").WithMessage("Şifrenizde en az bir özel karakter olmalıdır");


			//city rules
			RuleFor(x => x.CityID).GreaterThanOrEqualTo(0).WithMessage("Lütfen Şehir Seçiniz");


			//country rules
			RuleFor(x => x.CountryID).GreaterThanOrEqualTo(0).WithMessage("Lütfen Ülke Seçiniz");
				
			




		}
	}
}
