using KitapSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Services;

namespace KitapSitesi.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookService service;

        public HomeController(ILogger<HomeController> logger,IBookService service)
        {
            _logger = logger;
            this.service = service;
        }

        //index adlı metodu çalıştırdığın zaman bu fonksiyon tetiklenicek
        //inde sağ klik görünüm ekle 
        //eklenen görünüm view klasörünün home sub klasörünün index isimle dosyasında 
        public IActionResult Index(int page = 1)
        {
            var pageSize = 8;
            var books = service.GetBooks();

            var pagingBooks = books.OrderBy(p => p.Id)
                                         .Skip((page - 1) * pageSize)
                                         .Take(pageSize);

            /*
             *  1. sayfa: 0 atla 4 göster
             *  2. sayfa: 4 atla 4 göster
             *  3. sayfa: 8 atla 4 göster
             *  4. sayfa:12 atla 4 göster 
             */
            

            var totalBook = books.Count;

            var totalPage = Math.Ceiling((decimal)totalBook / pageSize);
            ViewBag.TotalPages = totalPage;
            return View(pagingBooks);
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
