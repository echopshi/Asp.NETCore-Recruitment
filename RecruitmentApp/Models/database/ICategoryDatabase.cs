using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentApp.Models.database
{
    public interface ICategoryDatabase
    {
        IQueryable<Category> Categories { get; }
        void SaveCategory(Category cat);
        Category DeleteCategory(int catId);
        void DeleteCategory(Category cat);
    }
}
