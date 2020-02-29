using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
	public class Customer
	{
		public int Id { get; set; }
		[Required, MaxLength(50), Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Required, MaxLength(50), Display(Name = "Last Name")]
		public string LastName { get; set; }
		public bool IsMemeber
		{
			get
			{
				return MembershipId.HasValue;
			}
		}
		[Display(Name = "Membership")]
		public int? MembershipId { get; set; }
		public Membership Membership { get; set; }
	}
}
