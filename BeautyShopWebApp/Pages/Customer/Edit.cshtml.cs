﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeautyShopWebApp
{
    public class EditModel : PageModel
    {
        private readonly ICustomerData customerData;
        private readonly IMembershipData membershipData;

        [BindProperty]
        public Customer Customer { get; set; }

        public IEnumerable<SelectListItem> Memberships { get; set; }
        public EditModel(ICustomerData customerData, IMembershipData membershipData)
        {
            this.customerData = customerData;
            this.membershipData = membershipData;
        }
        public IActionResult OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Customer = customerData.GetCustomerById(Id.Value);
                if(Customer == null)
                {
                    return RedirectToPage("./NotFound");
                }
            }
            else
            {
                Customer = new Customer();
            }
            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            Memberships = new SelectList(memberships, "Id", "Display");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Customer.Id == 0)
                {
                    Customer = customerData.Create(Customer);
                    TempData["Message"] = "The Object is created!";
                }
                else
                {
                    Customer = customerData.Update(Customer);
                    TempData["Message"] = "The Object is updated!";

                }
                customerData.Commit();
                return RedirectToPage("./List");
            }
            var memberships = membershipData.GetMemberships().ToList().Select(p => new { Id = p.Id, Display = p.MembershipType });
            Memberships = new SelectList(memberships, "Id", "Display");
            return Page();
        }
    }
}