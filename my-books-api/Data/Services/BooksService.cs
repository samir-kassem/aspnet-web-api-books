using my_books_api.Data.Models;
using my_books_api.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class BooksService 
    {

        private AppDbContext _db;
        public BooksService(AppDbContext db)
        {
            _db = db;
        }


        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };

            _db.Books.Add(_book);
            _db.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _db.Books_Authors.Add(_book_author);
                _db.SaveChanges();
            }
        }


        public List<Book> GetAllBooks() => _db.Books.ToList();

        public Book GetBookById(int id) => _db.Books.FirstOrDefault(b => b.Id == id);

        public Book UpdateBookById(int id, BookVM book)
        {
            var _book = _db.Books.FirstOrDefault(b => b.Id == id);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;

                _db.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }

        }
        

    }
}
