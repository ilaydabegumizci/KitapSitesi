using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;
using KitapSitesi.Data;
using Microsoft.EntityFrameworkCore;

namespace KitapSitesi.Services
{
    public class CategoryService : ICategoryService
    {
        private medyatekDbContext dbContext;

        public CategoryService(medyatekDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string CategoryById(int Id)
        {
            var category = dbContext.Categories.Find(Id);
            return category.Name.ToString();
        }

        public IList<Category> GetCategories()
        {
            return dbContext.Categories.AsNoTracking().ToList();
        }
    }
}
