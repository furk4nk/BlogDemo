using EntityLayer.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace BlogDemo.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="İsminizi Giriniz")]
		public string NameSurname { get; set; }
        [Required(ErrorMessage = "Mail Adresi Giriniz")]
        public string Email { get; set; }
		[Required(ErrorMessage = "Şifre Belirleyiniz")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Şifrenizi Tekrar Giriniz")]
		[Compare("Password", ErrorMessage = "Şifrelerin Eşleştiğinden Emin Olunuz")]
		public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }
        public bool Accept { get; set; }
    }	
}
	