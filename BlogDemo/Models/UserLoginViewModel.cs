using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
	public class UserLoginViewModel
	{
		[Required(ErrorMessage ="Email adresinizi Giriniz")]
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
