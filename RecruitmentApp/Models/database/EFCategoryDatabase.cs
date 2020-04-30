using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public class EFCategoryDatabase : ICategoryDatabase
    {
        private RecruitmentDBContext dbContext;

        public EFCategoryDatabase(RecruitmentDBContext context)
        {
            dbContext = context;
        }
        public IQueryable<Category> Categories {
            get
            {
                return dbContext.Categories
                    .Include(c => c.Jobs);
            }
        }

        public Category DeleteCategory(int catId)
        {
            Category dbCat = dbContext.Categories.FirstOrDefault(c => c.CatId == catId);
            if(dbCat != null)
            {
                foreach(Job j in dbCat.Jobs)
                {
                    dbContext.Jobs.Remove(j);
                }
                dbContext.Categories.Remove(dbCat);
                dbContext.SaveChanges();
            }
            return dbCat;
        }

        public void DeleteCategory(Category cat)
        {
            if (cat != null)
            {
                foreach (Job j in cat.Jobs)
                {
                    dbContext.Jobs.Remove(j);
                }
                dbContext.Categories.Remove(cat);
                dbContext.SaveChanges();
            }
        }

        public void SaveCategory(Category cat)
        {
            if(cat.CatId == 0)
            {
                dbContext.Categories.Add(cat);
            }
            else
            {
                Category dbCat = dbContext.Categories.First(c => c.CatId == cat.CatId);
                if(dbCat != null)
                {
                    dbCat.CatCode = cat.CatCode;
                    dbCat.CatDesc = cat.CatDesc;
                    dbCat.CatName = cat.CatName;
                    dbCat.Jobs = cat.Jobs;
                }
            }
            dbContext.SaveChanges();
        }
    }
}
