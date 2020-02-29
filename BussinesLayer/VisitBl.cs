using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Data;

namespace BusinessLayer
{
	public class VisitBl
	{
		private readonly IVisitData visitData;

		public VisitBl(IVisitData visitData)
		{
			this.visitData = visitData;
		}

		public Shopitem CreateService(double pay)
		{
			return new Shopitem
			{
				ShopitemType = ShopitemType.Service,
				Price = pay
			};
		}
		public Shopitem CreateProduct(double pay)
		{
			return new Shopitem
			{
				ShopitemType = ShopitemType.Product,
				Price = pay
			};
		}

		public double TotalExpences(int visitId)
		{
			var visit = visitData.GetVisitById(visitId);
			return TotalExpences(visit);
		}

		public double TotalExpences(Visit visit)
		{
			var sum = 0.0;
			foreach (var item in visit.Shopitems.Where(i => i.ShopitemType == ShopitemType.Product).ToList())
			{
				if (visit.Customer.IsMemeber)
				{
					sum += item.Price * (1 - visit.Customer.Membership.DiscountProducts);
				}
				else
				{
					sum += item.Price;
				}
			}
			foreach (var item in visit.Shopitems.Where(i => i.ShopitemType == ShopitemType.Service).ToList())
			{
				if (visit.Customer.IsMemeber)
				{
					sum += item.Price * (1 - visit.Customer.Membership.DiscountService);
				}
				else
				{
					sum += item.Price;
				}
			}
			return sum;
		}
	}
}
