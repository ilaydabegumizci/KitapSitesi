using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;
using KitapSitesi.Data;

namespace KitapSitesi.Services
{
    public class UserService : IUserService
    {
        private medyatekDbContext dbContext;

        public UserService(medyatekDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        User IUserService.ValidUser(string username, string password)
        {
            return dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public List<Book> GetWishListByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            user.Role = "User";
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

    }
}
