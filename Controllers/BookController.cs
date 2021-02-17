using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Services;
using KitapSitesi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace KitapSitesi.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService;
        private ICategoryService categoryService;
        private ICommentService commentService;

        public BookController(IBookService bookService, ICategoryService categoryService, ICommentService commentService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(books);
        }

        public IActionResult BooksByCategory(int categoryId)
        {
            var books = bookService.GetBooksByCategoryId(categoryId);
            return View(books);
        }


        private List<SelectListItem> getCategoriesForSelect()
        {
            var categories = categoryService.GetCategories();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            categories.ToList().ForEach(category => selectListItems.Add(new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            }));
            return selectListItems;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddBook()
        {
            List<SelectListItem> selectListItems = getCategoriesForSelect();

            ViewBag.Items = selectListItems;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> selectListItems = getCategoriesForSelect();
            ViewBag.Items = selectListItems;
            return View();

        }

        public IActionResult AddComment()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {

            if (ModelState.IsValid)
            {
                commentService.AddComment(comment);
                return RedirectToAction("Details", new { id = comment.BookId });
            }
            return View();

        }


        public IActionResult DeleteComment(int id)
        {
            var existingComment = commentService.GetCommentById(id);
            if (existingComment == null)
            {
                return NotFound();

            }
            commentService.DeleteComment(existingComment);
            return RedirectToAction(nameof(Details), new { id = existingComment.BookId });

        }

        public IActionResult Delete(int id)
        {
            var existingBook = bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();

            }
            var existingComments = commentService.GetCommentsByBookId(id);
            foreach (Comment commentDel in existingComments)
            {
                commentService.DeleteComment(commentDel);
            }
            bookService.DeleteBook(existingBook);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var existingBook = bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();

            }
            string categoryName = categoryService.CategoryById(existingBook.CategoryId);
            ViewBag.item = categoryName;
            return View(existingBook);

        }

        public IActionResult Edit(int id)
        {
            var existingBook = bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();

            }

            ViewBag.Items = getCategoriesForSelect();
            return View(existingBook);

        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                int affectedRowCount = bookService.EditBook(book);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
