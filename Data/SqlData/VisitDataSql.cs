using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.SqlData
{
	public class VisitDataSql : IVisitData
	{
		private readonly BeautyShopDbContext beautyShopDbContext;

		public VisitDataSql(BeautyShopDbContext beautyShopDbContext)
		{
			this.beautyShopDbContext = beautyShopDbContext;
		}

		public int Commit()
		{
			return beautyShopDbContext.SaveChanges();
		}

		public Visit Create(Visit visit)
		{
			beautyShopDbContext.Visits.Add(visit);
			return visit;
		}

		public Visit GetVisitById(int Id)
		{
			return beautyShopDbContext.Visits.SingleOrDefault(r => r.Id == Id);
		}

		public Visit GetVisitFullObjById(int Id)
		{
			return beautyShopDbContext.Visits
				.Include(c => c.Customer)
				.ThenInclude(v => v.Membership)
				.Include(c => c.Shopitems)
				.SingleOrDefault(r => r.Id == Id);
		}

		public IEnumerable<Visit> GetVisits(string searchTerm = null)
		{
			return beautyShopDbContext.Visits
				.Include(v => v.Customer)
				.ThenInclude(c => c.Membership)
				.Include(v => v.Shopitems)
				.Where(r => string.IsNullOrEmpty(searchTerm)
					|| r.Customer.FirstName.ToLower().StartsWith(searchTerm.ToLower())
					|| r.Customer.LastName.ToLower().StartsWith(searchTerm.ToLower()))
				.OrderBy(r => r.Customer.FirstName)
				.ToList();
		}
	}
}
