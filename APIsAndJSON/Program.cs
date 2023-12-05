using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            int limit = 5;

            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest/";
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < limit; i++)
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                var ronResponse = client.GetStringAsync(ronURL).Result;
                var ronQuote = JArray.Parse(ronResponse);
                Console.WriteLine("Kanye West");
                Console.WriteLine(kanyeQuote);
                Console.WriteLine();
                Console.WriteLine("Ron Swanson");
                Console.WriteLine(ronQuote[0]);
                Console.WriteLine();
            }
        }
    }
}
