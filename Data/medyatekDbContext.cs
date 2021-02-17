using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitapSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace KitapSitesi.Data
{
    public class medyatekDbContext:DbContext
    {
        public medyatekDbContext(DbContextOptions<medyatekDbContext> options) : base(options)
        {

        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql("server=127.0.0.1;port=3306;user=root;password=provfour;database=studentDB;")
                .UseLoggerFactory(LoggerFactory.Create(b => b.AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();


        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Category)
                        .WithMany(c => c.Books)
                        .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Comment>()
                       .HasOne(c => c.Book)
                       .WithMany(b => b.Comments)
                       .HasForeignKey(c => c.BookId);



            modelBuilder.Entity<UserWishList>().HasKey(uws => new { uws.UserId, uws.BookId });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserWishList> WishLists { get; set; }
    }
}
