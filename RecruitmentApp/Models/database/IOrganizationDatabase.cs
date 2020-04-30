using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public interface IOrganizationDatabase
    {
        IQueryable<Organization> Organizations { get; }
        // both create and update are done by save
        void SaveOrg(Organization org);
        Organization DeleteOrg(int orgId);
        void DeleteOrg(Organization org);
    }
}
