using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSitesi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string CommentofUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
