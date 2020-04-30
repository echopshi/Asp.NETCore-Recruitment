using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public class EFJobDatabase : IJobDatabase
    {
        private RecruitmentDBContext dbContext;

        public EFJobDatabase(RecruitmentDBContext context)
        {
            dbContext = context;
        }

        public IQueryable<Job> Jobs
        {
            get
            {
                return dbContext.Jobs;
            }
        }

        public void DeleteJob(int JobId)
        {
            Job dbJob = dbContext.Jobs.FirstOrDefault(j => j.JobId == JobId);
            if(dbJob != null)
            {
                dbContext.Jobs.Remove(dbJob);
                dbContext.SaveChanges();
            }
        }

        public void SaveJob(Job job)
        {
            if (job.JobId == 0)
            {
                dbContext.Jobs.Add(job);
            }
            else
            {
                Job dbJob = dbContext.Jobs.FirstOrDefault(j => j.JobId == job.JobId);
                if (dbJob != null)
                {
                    dbJob.JobCode = job.JobCode;
                    dbJob.JobName = job.JobName;
                    dbJob.JobDesc = job.JobDesc;
                    dbJob.PublishDate = job.PublishDate;
                    dbJob.VacancyNum = job.VacancyNum;
                }
            }
            dbContext.SaveChanges();
        }
    }
}
