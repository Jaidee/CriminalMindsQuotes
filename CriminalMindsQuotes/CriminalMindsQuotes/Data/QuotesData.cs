using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CriminalMindsQuotes.Data
{
    public class QuotesData
    {
        const string WebApiBase = "http://cmquotes.jaidee-software.com/api/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Quote>> LoadAllAsync()
        {
            var url = System.IO.Path.Combine(WebApiBase, "Quotes");
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(result);
        }

        public async Task<IEnumerable<Quote>> LoadAsyncQuoteId(string id)
        {
            var url = System.IO.Path.Combine(WebApiBase, "Quotes/Quote/", id);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(result);
        }

        public async Task<IEnumerable<Quote>> LoadAsyncEpisodeId(string id)
        {
            var url = System.IO.Path.Combine(WebApiBase, "Quotes/Episode/", id);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(result);
        }

        public async Task<IEnumerable<Quote>> LoadAsyncCharacterName(string name)
        {
            var url = System.IO.Path.Combine(WebApiBase, "Quotes/character/", name);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(result);
        }
    }
}
