using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class WriterPasswordChangeViewModel 
    {

        [Required(ErrorMessage ="Mevcut Şifrenizi Giriniz")]
        public string oldPassword { get; set; }

        [Required(ErrorMessage ="Yeni Şifrenizi Giriniz")]
        [Display(Name ="WriterPassword")]
        public string newPassword { get; set; }

        [Required(ErrorMessage ="Mevcut Şifrenizi Tekrar Giriniz")]
        [Compare("newPassword",ErrorMessage ="Şifreler Uyuşmuyor lütfen tekrar giriniz")]
        public string confirmNewPassword { get; set; }
    }
}
