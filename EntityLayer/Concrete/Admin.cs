using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : BaseEntity
    {

        // username , password , shortdescription ımageurl role
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get;  set; }
        public string Role { get; set; }
        public string Mail { get; set; }      
    }
}
