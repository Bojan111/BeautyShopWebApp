using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
	public class Visit
	{
		public int Id { get; set; }
		public Customer Customer { get; set; }
		[Required, Display(Name ="Customer")]
		public int? CustomerId { get; set; }
		public List<Shopitem> Shopitems { get; set; }

		public Visit()
		{
			Shopitems = new List<Shopitem>();
		}
	}
}
