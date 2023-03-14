using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Areas.WriterPanel.Models
{
    public class WriterViewModel
    {
        public int WriterID { get; set; }

        public string WriterName { get; set; }

        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }

        public bool WriterStatus { get; set; }

        public string WriterMail { get; set; }

        public string WriterPassword { get; set; }

        [Compare("WriterPassword", ErrorMessage = "Şifreler Uyuşmuyor,Kontrol Ediniz")]
        public string WriterConfirmPassword { get; set; }

    }
}
