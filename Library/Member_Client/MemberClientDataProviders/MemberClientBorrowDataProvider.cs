using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using Library_Common.Models;
using LibraryCommon.Models;
using Newtonsoft.Json;

namespace LibraryClient.DataProviders
{
    public static class MemberClientBorrowDataProvider
    {
        private static Uri _uniformResourceIdentifier = new Uri("http://localhost:5000/api/borrow");

        public static IEnumerable<Borrow> GetBorrows()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_uniformResourceIdentifier).Result;

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

                var response = client.PostAsync(_uniformResourceIdentifier, content).Result;
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
                var response = client.DeleteAsync(new Uri(_uniformResourceIdentifier.AbsoluteUri + "/" + id.ToString(CultureInfo.InvariantCulture))).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
