using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UDPMorsekodeReceiver
{
    class PostWorker
    {
        private const string baseURI = "http://localhost:56910/api/Morsestrings";

        public async void Post(string s1)
        {
            await PostMorseStringAsync(s1);
        }


        public async Task PostMorseStringAsync(string s1)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = JsonConvert.SerializeObject(s1);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await client.PostAsync(baseURI, content);
            }
        }
    }
}
