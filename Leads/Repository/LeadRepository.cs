using Leads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Repository
{
    public class LeadRepository : Repository<Lead>
    {
        public LeadRepository(LeadDataContext context) : base(context)
        {

        }

    }
}
