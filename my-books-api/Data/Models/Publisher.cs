using System.Collections.Generic;

namespace my_books_api.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // Relationship Properties

        public List<Book> Books { get; set; }
    }
}
