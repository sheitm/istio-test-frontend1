using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Frontend1.Model
{
    public class HttpRestBooksService : IBookService
    {
        private readonly string _baseUrl;

        public HttpRestBooksService(string baseUrl)
        {
            _baseUrl = baseUrl;
            if (!_baseUrl.EndsWith('/'))
            {
                _baseUrl += "/";
            }
        }

        public async Task<Book> Read(long id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(new Uri($"{_baseUrl}{id}"));

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<Book>(json);
        }

        public async Task<long> Create(Book book)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseUrl));
            request.Content = new StringContent(
                JsonConvert.SerializeObject(book),
                Encoding.UTF8,
                "application/json");

            var response = await client.SendAsync(request);

            var id = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(id))
            {
                return long.MinValue;
            }

            return long.Parse(id);
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
