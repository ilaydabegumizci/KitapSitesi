using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.Models
{
    public class Cart
    {
        private List<BookInCart> books = new List<BookInCart>();
        public void AddItem(Book book, int quantity)
        {
            var existingBook = books.FirstOrDefault(x => x.Book.Id == book.Id);
            if (existingBook == null)
            {
                books.Add(new BookInCart { Book = book, Quantity = quantity });
            }
            else
            {
                existingBook.Quantity += quantity;
            }
        }
        public void RemoveById(int id) {
            
            var existingBook = books.FirstOrDefault(x => x.Book.Id == id);
            if (existingBook.Quantity==1)
            {
                books.Remove(existingBook);
            }
            else
            {
                existingBook.Quantity -= 1;
            }

        }

        public void Remove(Book book) => books.RemoveAll(x => x.Book.Id == book.Id);

        public void Clear() => books.Clear();

        public decimal GetTotalValue()
        {
            return books.Sum(x => x.Book.Price * (decimal)(1 - x.Book.Discount) * x.Quantity);
        }

        public IEnumerable<BookInCart> Books => books;

    }
}