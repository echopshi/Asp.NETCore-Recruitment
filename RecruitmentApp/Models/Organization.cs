using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models
{
    public class Organization
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
