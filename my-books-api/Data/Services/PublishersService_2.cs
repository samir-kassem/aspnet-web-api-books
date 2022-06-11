using my_books_api.Data.Models;
using my_books_api.Data.Paging;
using my_books_api.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books_api.Data.Services
{
    public class PublishersService_2
    {
        private AppDbContext _db;
        public PublishersService_2(AppDbContext db)
        {
            _db = db;
        }

        public void AddPublisher(PublisherVM_2 publisher)
        {
            var _publisher = new Publisher_2()
            {
                Name = publisher.Name
            };

            _db.Publishers_2.Add(_publisher);
            _db.SaveChanges();
        }

        public List<Publisher_2> GetAllPublishers(string sortBy, string searchString,int? pageNumber)
        {
            var publishers = _db.Publishers_2.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        publishers = publishers.OrderByDescending(n => n.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                publishers = publishers.Where(n => n.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            int pageSize = 5;
            publishers = PaginationList<Publisher_2>.Create(publishers.AsQueryable(), pageNumber ?? 1, pageSize);

            return publishers;
        }

        public Publisher_2 GetPublisherById(int id)
        {
            var _publisher = _db.Publishers_2.FirstOrDefault(p => p.Id == id);
            if (_publisher == null)
                throw new Exception($"Publisher with id: {id} does not exist");
            
            return _publisher;
        }

        public PublisherWithBooksAndAuthorsVM_2 GetPublisherData(int id)
        {
            var _publisherData = _db.Publishers_2.Where(p => p.Id == id)
                .Select(p => new PublisherWithBooksAndAuthorsVM_2()
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(b => new BookAuthorVM_2()
                    {
                        BookName = b.Title,
                        BookAuthors = b.Book_Authors.Select(ba => ba.Author_2.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();

            if (_publisherData == null)
                throw new Exception($"Publisher Data id: {id} does not exist.");

            return _publisherData;
                     
        }

        public Publisher_2 UpdatePublisher(int id, PublisherVM_2 publisher)
        {
            var _publisher = _db.Publishers_2.FirstOrDefault(p => p.Id == id);
            if (_publisher == null)
                throw new Exception($"Publisher with id: {id} does not exist.");

            _publisher.Name = publisher.Name;
            _db.SaveChanges();
            return _publisher;
        }

        public void DeletePublisher(int id)
        {
            var _publisher = _db.Publishers_2.FirstOrDefault(p => p.Id == id);
            if (_publisher == null)
                throw new Exception($"Publisher with id: {id}");

            _db.Publishers_2.Remove(_publisher);
            _db.SaveChanges();
        }
    }
}
