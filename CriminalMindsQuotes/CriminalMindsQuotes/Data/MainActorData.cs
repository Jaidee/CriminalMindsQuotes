using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CriminalMindsQuotes.Data
{
    public class MainActorData
    {
        const string WebApiBase = "http://cmquotes.jaidee-software.com/api/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<MainActor>> LoadAllAsync()
        {
            var url = System.IO.Path.Combine(WebApiBase, "MainActors");
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<MainActor>>(result);
        }

        public async Task<MainActor> LoadAsyncActorId(string id)
        {
            var url = System.IO.Path.Combine(WebApiBase, "MainActors/", id);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<MainActor>(result);
        }
    }
}
