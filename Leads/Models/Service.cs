using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leads.Models
{
    public class Service
    {
        [Key]
        public int Service_Id { set; get; }
        public string Service_Name { set; get; }
        public IEnumerable<Lead> Leads { get; set; }
    }
}
