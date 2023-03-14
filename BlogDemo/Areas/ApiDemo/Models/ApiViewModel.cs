using System;

namespace BlogDemo.Areas.ApiDemo.Models
{
    public class ApiViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public string BlogType { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
    }
}
