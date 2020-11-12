using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leads.Models;
using Leads.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Leads.Controllers
{
    [Route("api/Lead")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private LeadDataContext context;
        private LeadRepository leadRepo;
        private ServiceRepository serviceRepo;
        public LeadController(LeadDataContext context)
        {
            this.context = context;
            this.leadRepo = new LeadRepository(context);
            this.serviceRepo = new ServiceRepository(context);
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var leads = leadRepo.GetAll();
            foreach (var lead in leads)
            {
                lead.Service = serviceRepo.GetByID(lead.Service_Id);
            }
            var descendingOrder = leads.OrderByDescending(i => i.Id);

            return Ok(descendingOrder);
        }
        [HttpGet("{id}", Name = "GetLeadById")]
        public IActionResult Get(int id)
        {
            var lead = leadRepo.GetByID(id);
            return Ok(lead);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Lead lead)
        {
            leadRepo.Insert(lead);
            string url = Url.Link("GetLeadById", new { id = lead.Id });
            return Created(url, lead);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Lead lead)
        {
            leadRepo.Edit(lead);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            leadRepo.Delete(id);
            return Ok();

        }
    }
}
