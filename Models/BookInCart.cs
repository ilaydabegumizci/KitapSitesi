using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.Models
{
    public class BookInCart
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
