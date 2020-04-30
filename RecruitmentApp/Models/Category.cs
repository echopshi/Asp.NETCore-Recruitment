using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models
{
    public class Category
    {
        public int CatId { get; set; }
        public string CatCode { get; set; }
        public string CatName { get; set; }
        public string CatDesc { get; set; }

        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
