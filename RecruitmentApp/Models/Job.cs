using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobCode { get; set; }
        public string JobName { get; set; }
        public string JobDesc { get; set; }
        public string PublishDate { get; set; }
        public int VacancyNum { get; set; }

    }
}
