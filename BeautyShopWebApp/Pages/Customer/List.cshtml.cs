using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShopWebApp
{
    public class ListModel : PageModel
    {
        private readonly ICustomerData customer;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public ListModel(ICustomerData customer)
        {
            this.customer = customer;
        }
        public void OnGet()
        {
            Customers = customer.GetCustomers(SearchTerm);
        }
    }
}