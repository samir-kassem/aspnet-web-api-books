using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Models;
using my_books_api.Data.ViewModels;
using System;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class AuthorsService_2
    {
        private AppDbContext _db;
        public AuthorsService_2(AppDbContext db)
        {
            _db = db;
        }

        public void AddAuthor(AuthorVM_2 author)
        {
            var _author = new Author_2()
            {
                FullName = author.FullName,
            };

            _db.Authors_2.Add(_author);
            _db.SaveChanges();
        }

        public AuthorWithBooksVM_2 GetAuthorData(int id)
        {
            var _authorData = _db.Authors_2.Where(a => a.Id == id)
                .Select(a => new AuthorWithBooksVM_2()
                {
                    FullName = a.FullName,
                    BookTitles = a.Book_Authors.Select(ba => ba.Book_2.Title).ToList()
                }).FirstOrDefault();

            if (_authorData == null)
                throw new Exception($"Author wiht id: {id} does not exist.");

            return _authorData;
        }

        public Author_2 UpdateAuthor(int id, AuthorVM_2 author)
        {
            var _author = _db.Authors_2.FirstOrDefault(a => a.Id == id);
            if (_author == null)
                throw new Exception($"Author with id: {id} does not exist.");

            _author.FullName = author.FullName;
            _db.SaveChanges();
            return _author;
        }

        public void DeleteAuthorById(int id)
        {
            var _author = _db.Authors_2.FirstOrDefault(a => a.Id == id);
            if (_author == null)
                throw new Exception($"Author with id: {id} does not exist.");

            _db.Authors_2.Remove(_author);
            _db.SaveChanges();
        }

        public AuthorWithPublishersVM_2 GetAuthorWithPublishers(int id)
        {
            var _authorData = _db.Authors_2.Where(a => a.Id == id)
                .Select(a => new AuthorWithPublishersVM_2()
                {
                    FullName = a.FullName,
                    PublisherNames = a.Book_Authors.Select(ba => ba.Book_2.Publisher_2.Name).ToList()
                }).FirstOrDefault();

            if(_authorData == null)
            {
                throw new Exception($"Author Data of id: {id} as not found.");
            }

            return _authorData;
        }
    }
}
