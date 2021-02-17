using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Services;
using KitapSitesi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KitapSitesi.Controllers
{
    public class CartController : Controller
    {
        private IBookService bookService;

        public CartController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string returnUrl)
        {
            var cart = GetCart();
            ViewBag.ReturnUrl = returnUrl;
            return View(cart);
        }


        public IActionResult FinishShopping()
        {
            var cart = GetCart();
            cart.Clear();
            SaveCart(cart);
            return View();
        }

      
        public IActionResult DeleteBookFromCart(int id)
        {
            Cart cart = GetCart();
            cart.RemoveById(id);
            SaveCart(cart);
            return RedirectToAction(nameof(Index), nameof(Cart), new { returnUrl = "Index" });
        }

        [HttpPost]
        public IActionResult AddToCart(int id, string returnUrl)
        {
            var selectedBook = bookService.GetBookById(id);
            if (selectedBook == null)
            {
                return NotFound();
            }

            Cart cart = GetCart() ?? new Cart();
            cart.AddItem(selectedBook, 1);
            SaveCart(cart);
            return RedirectToAction(nameof(Index), nameof(Cart), new { returnUrl = returnUrl });
        }

        Cart GetCart()
        {
            var data = HttpContext.Session.GetString("sepetim");
            if (data == null)
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Cart>(data);
            }

        }

        void SaveCart(Cart cart)
        {
            HttpContext.Session.SetString("sepetim", JsonConvert.SerializeObject(cart));

        }

        public IActionResult PrevFinishShopping()
        {
            var cart = GetCart();
            return View();
        }

    }
}