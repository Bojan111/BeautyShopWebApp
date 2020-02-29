using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public interface IMembershipData
	{
		IEnumerable<Membership> GetMemberships();
		Membership GetMembershipById(int? membershipId);
	}
}
