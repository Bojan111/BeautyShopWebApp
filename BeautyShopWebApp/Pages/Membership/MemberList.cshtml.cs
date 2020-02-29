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
    public class MemberListModel : PageModel
    {
        private readonly IMembershipData membershipData;
        public IEnumerable<Membership> Memberships { get; set; }

        public MemberListModel(IMembershipData membershipData)
        {
            this.membershipData = membershipData;
        }

        public void OnGet()
        {
            Memberships = membershipData.GetMemberships();
        }
    }
}