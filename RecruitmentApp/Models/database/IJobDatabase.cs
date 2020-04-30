using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    interface IJobDatabase
    {
        IQueryable<Job> Jobs { get; }
        void SaveJob(Job job);
        void DeleteJob(int JobId);

    }
}
