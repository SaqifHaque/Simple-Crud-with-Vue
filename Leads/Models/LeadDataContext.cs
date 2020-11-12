using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Models
{
    public class LeadDataContext : DbContext
    {
        public LeadDataContext(DbContextOptions<LeadDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        virtual public DbSet<Lead> Leads { get; set; }

        virtual public DbSet<Service> Services { get; set; }
    }
}
