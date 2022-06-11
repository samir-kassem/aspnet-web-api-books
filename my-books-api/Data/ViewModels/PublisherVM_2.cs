using System.Collections.Generic;

namespace my_books_api.Data.ViewModels
{
    public class PublisherVM_2
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM_2
    {
        public string Name { get; set; }

        public List<BookAuthorVM_2> BookAuthors { get; set; }
    }

    public class BookAuthorVM_2
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }

}
