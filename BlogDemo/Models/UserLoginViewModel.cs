using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
	public class UserLoginViewModel
	{
		[Required(ErrorMessage ="Email adresinizi Giriniz")]
		public string Username { get; set; }
		[Required(ErrorMessage ="Şifrenizi Giriniz")]
		public string Password { get; set; }
	}
}
