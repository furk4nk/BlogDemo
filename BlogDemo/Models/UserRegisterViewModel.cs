using EntityLayer.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BlogDemo.Models
{
	public class UserRegisterViewModel
	{
		public string WriterName { get; set; }
		public string WriterMail { get; set; }
		[Required(ErrorMessage = "Lütfen Şifre Belirleyiniz")]
		public string WriterPassword { get; set; }

		[Required(ErrorMessage = "Şifrenizi Tekrar Giriniz")]
		[Compare("WriterPassword", ErrorMessage = "Şifrelerin Eşleştiğinden Emin Olunuz")]
		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage ="ülke seçiniz lütfen")]
		public int CountryID { get; set; } 
		public int CityID { get; set; }
	}	
}
	