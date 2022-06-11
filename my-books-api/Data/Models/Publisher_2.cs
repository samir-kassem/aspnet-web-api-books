using System.Collections.Generic;

namespace my_books_api.Data.Models
{
    public class Publisher_2
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Relations 
        public List<Book_2> Books { get; set; }
    }
}
