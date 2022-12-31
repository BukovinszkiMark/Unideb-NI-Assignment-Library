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
    class MemberClientBorrowDataProvider
    {
        private const string _url = "http://localhost:5000/api/borrow";

        public static IEnumerable<Borrow> GetBorrows()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var borrows = JsonConvert.DeserializeObject<IEnumerable<Borrow>>(rawData);
                    return borrows;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateBorrow(Borrow borrow)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(borrow);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteBorrow(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
