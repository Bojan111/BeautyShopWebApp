using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.SqlData
{
	public class CustomerDataSql : ICustomerData
	{
		private readonly BeautyShopDbContext beautyShopDbContext;

		public CustomerDataSql(BeautyShopDbContext beautyShopDbContext)
		{
			this.beautyShopDbContext = beautyShopDbContext;
		}

		public int Commit()
		{
			return beautyShopDbContext.SaveChanges();
		}

		public Customer Create(Customer customer)
		{
			beautyShopDbContext.Customer.Add(customer);
			return customer;
		}

		public Customer GetCustomerById(int Id)
		{
			return beautyShopDbContext.Customer
				.Include(c => c.Membership)
				.SingleOrDefault(r => r.Id == Id);
		}

		public IEnumerable<Customer> GetCustomers(string searchTerm = null)
		{
			return beautyShopDbContext.Customer
				.Include(c => c.Membership)
				.Where(r => string.IsNullOrEmpty(searchTerm)
					|| r.FirstName.ToLower().StartsWith(searchTerm.ToLower())
					|| r.LastName.ToLower().StartsWith(searchTerm.ToLower()))
				.OrderBy(r => r.FirstName)
				.ToList();
		}

		public Customer Update(Customer customer)
		{
			beautyShopDbContext.Entry(customer).State = EntityState.Modified;
			return customer;
		}
	}
}
