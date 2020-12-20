using System;
using System.IO;
using System.Net;

using Newtonsoft.Json.Linq;

namespace StarCitizenProject
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            Stream data = client.OpenRead("https://api.starcitizen-api.com/f3336da3459e5ed3ca5ef7ddd556159b/v1/live/user/dymerz");
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            JObject parsed = JObject.Parse(s);

            foreach(var pair in parsed)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
            data.Close();
            reader.Close();
        }
    }
}
