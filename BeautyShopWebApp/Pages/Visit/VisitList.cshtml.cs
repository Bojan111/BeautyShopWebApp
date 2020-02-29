using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Core;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautyShopWebApp
{
    public class VisitListModel : PageModel
    {
        private readonly IVisitData visitData;
        private readonly VisitBl visitBl;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        [TempData]
        public string Message { get; set; }
        public IEnumerable<Visit> Visits { get; set; }
        public VisitListModel(IVisitData visitData, VisitBl visitBl)
        {
            this.visitData = visitData;
            this.visitBl = visitBl;
        }
        public double GetTotalExpenses(Visit visit)
        {
            return visitBl.TotalExpences(visit);
        }
        public void OnGet()
        {
            Visits = visitData.GetVisits(SearchTerm);
        }
    }
}