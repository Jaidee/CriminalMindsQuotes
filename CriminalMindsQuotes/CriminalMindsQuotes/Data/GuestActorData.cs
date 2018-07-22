using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CriminalMindsQuotes.Data
{
    public class GuestActorData
    {
        const string WebApiBase = "http://cmquotes.jaidee-software.com/api/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<GuestActor>> LoadAllAsync()
        {
            var url = System.IO.Path.Combine(WebApiBase, "GuestActors");
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<GuestActor>>(result);
        }

        public async Task<IEnumerable<GuestActor>> LoadAsyncEpisodeId(string id)
        {
            var url = System.IO.Path.Combine(WebApiBase, "GuestActors/Episode/", id);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<GuestActor>>(result);
        }

        public async Task<IEnumerable<GuestActor>> LoadAsyncCharacterName(string name)
        {
            var url = System.IO.Path.Combine(WebApiBase, "GuestActors/Character/", name);
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<GuestActor>>(result);  
        }
    }
}
