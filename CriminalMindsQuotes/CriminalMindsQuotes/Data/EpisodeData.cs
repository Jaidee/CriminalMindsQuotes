using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CriminalMindsQuotes.Data
{
    public class EpisodeData
    {
        const string WebAPiBase = "http://cmquotes.jaidee-software.com/api/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Episode>> LoadAllAsync()
        {
            var url = System.IO.Path.Combine(WebAPiBase, "Episodes");
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Episode>>(result);
        }

        public async Task<Episode> LoadAsyncId(string id)
        {
            var url = System.IO.Path.Combine(WebAPiBase, "Episodes/", id);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Episode>(result);
        }

        //TODO: For tablets Create Load take
        
    }
}
