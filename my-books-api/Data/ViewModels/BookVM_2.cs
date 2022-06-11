using System;
using System.Collections.Generic;

namespace my_books_api.Data.ViewModels
{
    public class BookVM_2
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string CoverUrl { get; set; }
        public string Genre { get; set; }


        // Relations 
        public int PublisherId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
