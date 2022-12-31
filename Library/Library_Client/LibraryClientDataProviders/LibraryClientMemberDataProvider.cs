using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Library_Common.Models;
using Newtonsoft.Json;

namespace Library_Client.DataProviders
{
    public static class LibraryClientMemberDataProvider
    {
        private static Uri _uniformResourceIdentifier = new Uri("http://localhost:5000/api/member");

        public static IEnumerable<Member> GetMembers()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_uniformResourceIdentifier).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var members = JsonConvert.DeserializeObject<IEnumerable<Member>>(rawData);
                    return members;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void CreateMember(Member member)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(member);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_uniformResourceIdentifier, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
