using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;

namespace KitapSitesi.Services
{
    public interface ICommentService
    {
        List<Comment> GetCommentsByBookId(int bookId);
        void AddComment(Comment comment);
        void DeleteComment(Comment comment);
        Comment GetCommentById(int id);
    }
}
