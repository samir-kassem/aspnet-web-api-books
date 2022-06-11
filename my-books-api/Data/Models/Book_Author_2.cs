namespace my_books_api.Data.Models
{
    public class Book_Author_2
    {
        public int Id { get; set; }
        public int Book_2Id { get; set; }
        public Book_2 Book_2 { get; set; }

        public int Author_2Id { get; set; }
        public Author_2 Author_2 { get; set; }
    }
}
