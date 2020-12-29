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
            User tim = new User(parsed);

            foreach(var pair in parsed)
            {
                // if(pair.Key == "data") {
                //     //Console.WriteLine(pair.Value);
                //     JObject innerParse = JObject.Parse(pair.Value.ToString());
                //     foreach(var innerPair in innerParse) {
                //         if(innerPair.key == "organization") {
                //             Console.WriteLine(pair.Value);
                //         }
                //     }
                // }
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
            data.Close();
            reader.Close();
        }
    }


    //Map Class as Entity in Database   
    class User 
    {
        String name;

        JObject response;

        public User(JObject jo) {
            setResponse(jo);
        }


        public void setResponse(JObject jo) {
            this.response = jo;
        }


        public void setName() {
            //this.name = response.getName("handle");

            

        }

    }
}
