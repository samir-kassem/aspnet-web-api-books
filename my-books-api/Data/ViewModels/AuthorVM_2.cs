using System.Collections.Generic;

namespace my_books_api.Data.ViewModels
{
    public class AuthorVM_2
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM_2
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }

    public class AuthorWithPublishersVM_2
    {
        public string FullName { get; set; }
        public List<string> PublisherNames { get; set; }
    }

}
