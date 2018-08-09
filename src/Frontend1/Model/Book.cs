using System;

namespace Frontend1.Model
{
    public class Book
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string CreatedById { get; set; }
    }
}
