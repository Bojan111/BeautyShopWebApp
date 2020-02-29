using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.SqlData
{
	public class MembershipDataSql : IMembershipData
	{
		private readonly BeautyShopDbContext beautyShopDbContext;

		public MembershipDataSql(BeautyShopDbContext beautyShopDbContext)
		{
			this.beautyShopDbContext = beautyShopDbContext;
		}

		public Membership GetMembershipById(int? membershipId)
		{
			return beautyShopDbContext.Membership.SingleOrDefault(x => x.Id == membershipId);
		}

		public IEnumerable<Membership> GetMemberships()
		{
			return beautyShopDbContext.Membership.ToList();
		}
	}
}
