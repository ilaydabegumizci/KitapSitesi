using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;

namespace KitapSitesi.Services
{
    public interface IUserService
    {
        User ValidUser(string username, string password);
        void AddUser(User user);
        List<Book> GetWishListByUserId(int userId);
    }
}
