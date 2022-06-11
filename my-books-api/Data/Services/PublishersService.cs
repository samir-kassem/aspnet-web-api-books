using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Models;
using my_books_api.Data.Paging;
using my_books_api.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _db;

        public PublishersService(AppDbContext db)
        {
            _db = db;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher();
            _publisher.Name = publisher.Name;

            _db.Publishers.Add(_publisher);
            _db.SaveChanges();

            return _publisher;
        }

        public List<Publisher> GetAllPublishers(string sortBy, string searchString, int? pageNumber)
        {
            var all_publishers = _db.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        all_publishers = all_publishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;

                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                //all_publishers = all_publishers.Where(n => n.Name.ToLower().Contains(searchString.ToLower())).ToList();
                all_publishers = all_publishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList(); // Another way to implement case insesnitive search.
            }

            // Pagination

            int pageSize = 5;
            all_publishers = PaginationList<Publisher>.Create(all_publishers.AsQueryable(), pageNumber ?? 1, pageSize);


            return all_publishers;
        }

        public Publisher GetPublisherById(int id) => _db.Publishers.FirstOrDefault(p => p.Id == id);

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _db.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(b => new BookAuthorVM()
                    {
                        BookName = b.Title,
                        BookAuthors = b.Book_Authors.Select(ba => ba.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);

            if(_publisher != null)
            {
                _db.Publishers.Remove(_publisher);
                _db.SaveChanges();
            } else
            {
                throw new Exception($"Publisher with id: {id} does not exist.");
            }
        }
    }
}
