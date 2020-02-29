using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
	public class Shopitem
	{
		public int Id { get; set; }
		public double Price { get; set; }
		
		public ShopitemType ShopitemType { get; set; }


		public int VisitId { get; set; }
		public Visit Visit { get; set; }
	}
}
