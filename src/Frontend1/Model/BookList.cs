using System.Collections.Generic;

namespace Frontend1.Model
{
    public class BookList
    {
        public IEnumerable<Book> Books;
        public string NextPageToken;
    }
}
