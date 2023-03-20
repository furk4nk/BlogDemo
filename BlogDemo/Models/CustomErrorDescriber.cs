using Microsoft.AspNetCore.Identity;

namespace BlogDemo.Models
{
	public class CustomErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError()
			{
				Description = "Sistemde Kayıtlı Email",
				Code="DuplicateEmail"
			};
		}
		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError()
			{
				Description="Geçersiz Mail Adresi",
				Code=nameof(InvalidEmail)
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError()
			{
				Description="Kullanıcı Adı Sistemde Kayıtlı",
				Code = nameof(DuplicateUserName)
			};
		}
		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError()
			{
				Description="Kullanıcı Adı Geçersiz",
				Code =nameof(InvalidUserName)
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Description="Şifre Uzunluğu minimum 6 karakter olmalıdır",
				Code="PasswordTooShort"
			};
		}
		public override IdentityError UserAlreadyHasPassword()
		{
			return new IdentityError()
			{
				Description="Şifrenizi Aynı Şifre İle Değiştiremezsiniz",
				Code="UserAlreadyHasPassword"
			};
		}
		public override IdentityError PasswordMismatch()
		{
			return new IdentityError()
			{
				Description="Şifreniz Yanlış",
				Code="PasswordMismatch"
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Description="Şifreniz En Az 1 Rakamdan Oluşmalı [0-9]",
				Code="PasswordRequiresDigit"
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Description="Şifreniz En Az 1 Büyük Küçük İçermelidir ['a'-'z']",
				Code="PasswordRequiresLower"
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Description="Şifreniz En Az 1 Büyük Harf İçermeli ['A'-'Z']",
				Code="PasswordRequiresUpper"
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Description="Şifreniz En Az 1 Alfanümerik olmayan Karakter içermeli [!,',^,+,%,&,...?]",
				Code="PasswordRequiresNonAlphanumeric"
			};
		}

	}
}
