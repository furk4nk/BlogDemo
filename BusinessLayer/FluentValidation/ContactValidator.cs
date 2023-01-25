using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
	public class ContactValidator : AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			// Contact User Name Rules
			RuleFor(x => x.ContactUserName).NotEmpty().WithMessage("İsim Alanını Boş Geçemezsiniz")
				.MinimumLength(3).WithMessage("İsminiz en az 3 karakter olacak şekilde giriniz")
				.MaximumLength(30).WithMessage("İsminizi en fazla 30 karakter olacak şekilde giriniz");


			//contact Mail Rules 
			RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Eposta Adresi Boş Geçilemez")
				.EmailAddress().WithMessage("Geçersiz Eposta Adresi");


			// Contact Subject Rules
			RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu Boş Geçilemez")
				.MinimumLength(5).WithMessage("Konu en az 5 karakter olacak şekilde giriniz")
				.MaximumLength(50).WithMessage("Konu en fazla 50 karakter olacak şekilde giriniz");


			// Contact Message Rules
			RuleFor(x => x.ContactMessage).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez")
				.MinimumLength(10).WithMessage("Mesajınız en az 10 karakter olmalıdır")
				.MaximumLength(4000).WithMessage("mesajınız en fazla 4000 karakter olmalıdır");			
		}
	}
}
