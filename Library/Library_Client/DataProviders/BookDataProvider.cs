using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Library_Common.Models;
using Newtonsoft.Json;

namespace Library_Client.DataProviders
{
    class BookDataProvider
    {
        private const string _url = "http://localhost:5000/api/book";

        public static IEnumerable<Book> GetBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(rawData);
                    return books;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

    }
}
