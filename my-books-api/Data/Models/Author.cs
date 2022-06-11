using System.Collections.Generic;

namespace my_books_api.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
         public string FullName { get; set; }

        // Relationship Properties

        public List<Book_Author> Book_Authors { get; set; }

    }
}
