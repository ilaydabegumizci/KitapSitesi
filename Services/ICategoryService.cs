using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;

namespace KitapSitesi.Services
{
    public interface ICategoryService
    {
        IList<Category> GetCategories();
        String CategoryById(int Id);
    }
}
