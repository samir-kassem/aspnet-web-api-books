using System.Collections.Generic;

namespace my_books_api.Data.Models
{
    public class Author_2
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // Relations
        public List<Book_Author_2> Book_Authors { get; set; }
    }
}
