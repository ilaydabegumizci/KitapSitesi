using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;
using KitapSitesi.Data;
using Microsoft.EntityFrameworkCore;

namespace KitapSitesi.Services
{
    public class BookService : IBookService
    {
        private medyatekDbContext dbContext;

        public BookService(medyatekDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
        }

        public int EditBook(Book book)
        {

            dbContext.Entry(book).State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            var book = dbContext.Books.Find(id);
            return book;
        }

        public List<Book> GetBooks()
        {
            var books = dbContext.Books.Include(x => x.Category).AsNoTracking().ToList();
            return books;
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
        {
            return dbContext.Books.AsNoTracking().Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Comment> GetCommentsByBookId(int bookId)
        {
            return dbContext.Comment.AsNoTracking().Where(c => c.BookId == bookId).ToList();
        }

        public List<Book> GetLastNBooks(int N)
        {

            var books = dbContext.Books.OrderByDescending(m => m.Id)
                     .Take(N).AsNoTracking().ToList();
            return books;
            /*.Where(m => m.<field> == data) 
                     .OrderByDescending(m => m.<field>) 
                     .Take(n); */
        }
    }
}
