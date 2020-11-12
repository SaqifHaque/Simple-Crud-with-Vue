using Leads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Repository
{
    public class ServiceRepository : Repository<Service>
    {
        public ServiceRepository(LeadDataContext context):base(context)
        {
        }

    }
}
