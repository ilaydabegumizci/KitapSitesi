using KitapSitesi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.ViewComponents
{
    public class CategoriesMenu : ViewComponent
    {
        private ICategoryService categoryService;

        public CategoriesMenu(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }


        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }
    }
}
