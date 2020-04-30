using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public class EFOrganizationDatabase : IOrganizationDatabase
    {
        private RecruitmentDBContext dbContext;

        public EFOrganizationDatabase(RecruitmentDBContext context)
        {
            dbContext = context;
        }
        public IQueryable<Organization> Organizations
        {
            get
            {
                return dbContext.Organizations
                    .Include(o => o.Categories)
                    .ThenInclude(c => c.Jobs);
            }
        }

        public void SaveOrg(Organization org)
        {
            if(org.OrgId == 0)
            {
                dbContext.Organizations.Add(org);
            }
            else
            {
                Organization dbOrg = dbContext.Organizations.FirstOrDefault(o => o.OrgId == org.OrgId);
                if (dbOrg != null)
                {
                    dbOrg.OrgName = org.OrgName;
                    dbOrg.Address = org.Address;
                    dbOrg.Email = org.Email;
                    dbOrg.PostalCode = org.PostalCode;
                    dbOrg.PhoneNo = org.PhoneNo;
                    dbOrg.Website = org.Website;
                    dbOrg.Categories = org.Categories;
                }
            }
            dbContext.SaveChanges();
        }

        public Organization DeleteOrg(int orgId)
        {
            Organization dbOrg = dbContext.Organizations.FirstOrDefault(o => o.OrgId == orgId);
            if(dbOrg != null)
            {
                foreach(Category c in dbOrg.Categories)
                {
                    foreach(Job j in c.Jobs)
                    {
                        dbContext.Jobs.Remove(j);
                    }
                    dbContext.Categories.Remove(c);
                }
                dbContext.Organizations.Remove(dbOrg);
                dbContext.SaveChanges();
            }
            return dbOrg;
        }

        public void DeleteOrg(Organization org)
        {
            if (org != null)
            {
                foreach (Category c in org.Categories)
                {
                    foreach (Job j in c.Jobs)
                    {
                        dbContext.Jobs.Remove(j);
                    }
                    dbContext.Categories.Remove(c);
                }
                dbContext.Organizations.Remove(org);
                dbContext.SaveChanges();
            }
        }
    }
}
