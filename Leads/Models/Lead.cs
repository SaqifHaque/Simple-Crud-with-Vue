using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Leads.Models
{
    public class Lead
    {
        [Key]
        public int Id { set; get; }

        public string Name { set; get; }

        public string Email { set; get; }

        public string Contact { set; get; }

        public string Company { set; get; }

        public int Service_Id { set; get; }

        [ForeignKey("Service_Id")]
        public Service Service { set; get; }

    }
}
