using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;
using KitapSitesi.Services;

namespace KitapSitesi.ViewComponents
{
    public class NewReleases:ViewComponent
    {
        private IBookService bookService;

        public NewReleases(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public IViewComponentResult Invoke()
        {
            var newReleased = bookService.GetLastNBooks(5);
            return View(newReleased);
            //return View();
        }
    }
}
