using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leads.Models;
using Leads.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leads.Controllers
{
    [Route("api/Service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private LeadDataContext context;
        private ServiceRepository serviceRepo;
        public ServiceController(LeadDataContext context)
        {
            this.context = context;
            this.serviceRepo = new ServiceRepository(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var services = serviceRepo.GetAll();

            return Ok(services);
        }
    }
}
