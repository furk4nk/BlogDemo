using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        public string WriterName { get; set; }

        public string WriterAbout { get; set; }

        public string WriterImage { get; set; }
        
        public bool WriterStatus { get; set; }
        
        public string WriterMail { get; set; }
        
        public string WriterPassword { get; set; }
        public virtual ICollection<Message2> WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReceiver { get; set; }


        public List<Blog> Blogs { get; set; }
        public int CountryID { get; set; }
        public Country country { get; set; }
		public int CityID { get; set; }
		public City city { get; set; }
		public int DisctrictID { get; set; }
		public District districts { get; set; }

	}
}
