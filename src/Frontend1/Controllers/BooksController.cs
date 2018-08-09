using Frontend1.Model;
using Microsoft.AspNetCore.Mvc;

namespace Frontend1.Controllers
{
    [Produces("application/json")]
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private const int PageSize = 10;

        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        //// GET: api/Books
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return _store.List(PageSize,)
        //}

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Book Get(long id)
        {
            return _service.Read(id).Result;
        }

        // POST: api/Books
        [HttpPost]
        public long Post([FromBody]Book value)
        {
            return _service.Create(value).Result;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book value)
        {
            _service.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
