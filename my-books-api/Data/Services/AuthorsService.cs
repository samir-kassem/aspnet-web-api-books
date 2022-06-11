using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Models;
using my_books_api.Data.ViewModels;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _db;

        public AuthorsService(AppDbContext db)
        {
            _db = db;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author();
            _author.FullName = author.FullName;

            _db.Authors.Add(_author);
            _db.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int id)
        {
            var _author = _db.Authors.Where(a => a.Id == id).Select(a => new AuthorWithBooksVM()
            {
                FullName = a.FullName,
                BookTitles = a.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }


    }
}
