using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kullanıcı ismi boş olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mail adresi boş olamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Kullanıcı şifresi boş olamaz")]
        public string Password { get; set; }
        public string Role { get; set; }
     
        public IList<UserWishList> WishList { get; set; }
    }
}
