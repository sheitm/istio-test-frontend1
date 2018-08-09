using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend1.Model
{
    public interface IBookService
    {
        Task<Book> Read(long id);
        Task<long> Create(Book book);
        void Update(Book book);
        void Delete(long id);
    }
}
