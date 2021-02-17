using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Services;

namespace KitapSitesi.ViewComponents
{
    public class ShowComments : ViewComponent
    {
        private ICommentService commentService;

        public ShowComments(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        public IViewComponentResult Invoke(int bookId)
        {
            var comments = commentService.GetCommentsByBookId(bookId);
            return View(comments);

        }


    }
}
