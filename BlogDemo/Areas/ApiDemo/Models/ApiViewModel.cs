using System;

namespace BlogDemo.Areas.ApiDemo.Models
{
    public class ApiViewModel
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContext { get; set; }
        public string BlogThumbNailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public int WriterID { get; set; }
    }
}
