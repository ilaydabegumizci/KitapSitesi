using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;

namespace KitapSitesi.Services
{
    public interface IBookService
    {
        List<Book> GetBooks();
        List<Book> GetBooksByCategoryId(int categoryId);
        List<Comment> GetCommentsByBookId(int bookId);
        void AddBook(Book book);
        Book GetBookById(int id);
        int EditBook(Book book);
        void DeleteBook(Book book);
        List<Book> GetLastNBooks(int N);
    }
}
