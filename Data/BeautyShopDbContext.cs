using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
	public class BeautyShopDbContext : DbContext
	{
        public BeautyShopDbContext(DbContextOptions<BeautyShopDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Membership> Membership { get; set; }
    }
}
