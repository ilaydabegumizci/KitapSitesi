using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen kitap adı girin.")]
        [Display(Name = "Kitap Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen yazar adı giriniz...")]
        [Display(Name = "Açıklama")]

        public string Author { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama giriniz...")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        public double Rating { get; set; }

        public decimal Price { get; set; }
        public double Discount { get; set; }

        public string ImageUrl { get; set; }


        public IList<Comment> Comments { get; set; }

        //Book are in user's wishlists
        public IList<UserWishList> WishList { get; set; }

    }
}
