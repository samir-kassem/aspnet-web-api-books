using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Models;
using my_books_api.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class BooksService_2
    {
        private AppDbContext _db;
        public BooksService_2(AppDbContext db)
        {
            _db = db;
        }

        public void AddBookWithAuthors(BookVM_2 book)
        {
            try
            {
                var _book = new Book_2()
                {
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead.Value : null,
                    Rate = book.IsRead ? book.Rate.Value : null,
                    CoverUrl = book.CoverUrl,
                    Genre = book.Genre,
                    DateAdded = DateTime.Now,
                    Publisher_2Id = book.PublisherId
                };

                _db.Books_2.Add(_book);
                _db.SaveChanges();

                foreach (int author_id in book.AuthorIds)
                {
                    var _book_author = new Book_Author_2()
                    {
                        Book_2Id = _book.Id,
                        Author_2Id = author_id
                    };

                    _db.Books_Authors_2.Add(_book_author);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        public List<Book_2> GetAllBooks() => _db.Books_2.ToList();
        public Book_2 GetBookById(int id)
        {
            var _book = _db.Books_2.FirstOrDefault(b => b.Id == id);
            if (_book == null)
                throw new Exception($"Book with id: {id} does not exist");

            return _book;
        }
        public Book_2 UpdateBookById(int id, BookVM_2 book)
        {
            var _book = _db.Books_2.FirstOrDefault(b => b.Id == id);
            if(_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _db.SaveChanges();
                return _book;
            }
            throw new Exception($"Book with id: {id} does not exist.");
        }
        public void DeleteBookById(int id)
        {
            var _book = _db.Books_2.FirstOrDefault(b => b.Id == id);
            if (_book == null)
            {
                throw new Exception($"Book with id {id} does not exist");
                
            }
            _db.Books_2.Remove(_book);
            _db.SaveChanges();
        }
        public List<Book_2> GetBooksByAuthor(int authorId)
        {
            var response = _db.Books_2.Where(b => b.Book_Authors.Select(ba => ba.Author_2Id).FirstOrDefault() == authorId).ToList();
            return response;
        }
    }
}
