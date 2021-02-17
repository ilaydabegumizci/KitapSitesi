using KitapSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Data;
using Microsoft.EntityFrameworkCore;

namespace KitapSitesi.Services
{
    public class CommentService : ICommentService
    {
        private medyatekDbContext dbContext;

        public CommentService(medyatekDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddComment(Comment comment)
        {
            dbContext.Comment.Add(comment);
            dbContext.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            dbContext.Comment.Remove(comment);
            dbContext.SaveChanges();
        }

        public Comment GetCommentById(int id)
        {
            var comment = dbContext.Comment.Find(id);
            return comment;
        }

        public List<Comment> GetCommentsByBookId(int bookId)
        {
            return dbContext.Comment.AsNoTracking().Where(c => c.BookId == bookId).ToList();
        }
    }
}
