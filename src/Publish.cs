using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Project_Broban
{
    public class Publish
    {
        public async Task PostTime(String name, int time)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "name", name },
                    { "time", time.ToString() }
                };

                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("http://127.0.0.1/website/publish.php", content);
                var responseString = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine(responseString);
            }
        }
    }
}
