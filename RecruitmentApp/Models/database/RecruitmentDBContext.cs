using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public class RecruitmentDBContext : DbContext
    {
        public RecruitmentDBContext(DbContextOptions<RecruitmentDBContext> options) : base(options) { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Job> Jobs { get; set; }
    }
}
