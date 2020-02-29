using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public interface ICustomerData
	{
		Customer Create(Customer customer);

		Customer GetCustomerById(int Id);
		Customer Update(Customer customer);
		int Commit();
		IEnumerable<Customer> GetCustomers(string searchTerm = null);
	}
}
