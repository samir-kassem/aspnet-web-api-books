using Microsoft.EntityFrameworkCore;
using my_books_api.Data.Models;

namespace my_books_api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ai => ai.AuthorId);
            

            modelBuilder.Entity<Book_Author_2>()
                .HasOne(b => b.Book_2)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ba => ba.Book_2Id);

            modelBuilder.Entity<Book_Author_2>()
                .HasOne(a => a.Author_2)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ai => ai.Author_2Id);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors{ get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        public DbSet<Book_2> Books_2 { get; set; }
        public DbSet<Author_2> Authors_2{ get; set; }
        public DbSet<Publisher_2> Publishers_2 { get; set; }
        public DbSet<Book_Author_2> Books_Authors_2{ get; set; }

    }
}
