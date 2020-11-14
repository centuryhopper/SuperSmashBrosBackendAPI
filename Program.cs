using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;



namespace AspNetCoreWebAPI
{
    public class Program
    {
        static void p(dynamic m) => Console.WriteLine(m);

        public static async Task Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();

            // initialize API caller for getting online requests
            // APiHelper.InitializeClient();

            Console.ForegroundColor = ConsoleColor.Red;

            p("hi");
            Console.ResetColor();


            #region star wars species

            // StarWarsSpeciesModel s = await StarWarsSpeciesController.GetSpecies(3);

            // print(s.Name);
            // print(s.Average_Lifespan);

            #endregion

            #region star wars people

            // StarWarsPeopleModel p = await GetStarWarsPeople(6);

            // print(p.name);
            // print(p.birth_year);
            // print(p.gender);
            // print(p.height);
            // print(p.eye_color);

            #endregion


            #region GET request example from an online url
            // string url = String.Format("https://swapi.dev/api/species/3/");

            // // middle man between online url and code AKA fetch from javascript
            // WebRequest requestObject = WebRequest.Create(url);
            // requestObject.Method = "GET";
            // requestObject.Credentials = new NetworkCredential("USER", "PASS");

            // HttpWebResponse responseObject = requestObject.GetResponse() as HttpWebResponse;

            // string fetchedInfo;
            // using (Stream stream = responseObject.GetResponseStream())
            // {
            //     using(StreamReader reader = new StreamReader(stream))
            //     {
            //         fetchedInfo = reader.ReadToEnd();
            //     }
            // }

            // print(fetchedInfo);
            #endregion

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
