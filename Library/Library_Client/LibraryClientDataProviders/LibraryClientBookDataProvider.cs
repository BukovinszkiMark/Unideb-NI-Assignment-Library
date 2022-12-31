using System;
using System.Collections.Generic;
using System.Net.Http;
using Library_Common.Models;
using LibraryCommon.Models;
using Newtonsoft.Json;

namespace LibraryClient.DataProviders
{
    public static class LibraryClientBookDataProvider
    {
        private static Uri _uniformResourceIdentifier = new Uri("http://localhost:5000/api/book");

        public static IEnumerable<Book> GetBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_uniformResourceIdentifier).Result;

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
