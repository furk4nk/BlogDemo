using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class District
	{
		[Key]
		public int DisctrictID { get; set; }
		public string DisctrictName { get; set; }
		public int CityID { get; set; }
		public City city { get; set; }
	}
}
