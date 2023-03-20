using Microsoft.AspNetCore.Http;

namespace BlogDemo.Areas.WriterPanel.Models
{
    public class WriterUpdateViewModel
    {
        public int ID { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; } // aspUser
        public string Email { get; set; }   
        public IFormFile WriterImage { get; set; } // model
        public string WriterAbout { get; set; } // Writer
    }
}
    