using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Net;
using System.IO;
using Newtonsoft.Json;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Controllers;
using AspNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore.Design;


namespace AspNetCoreWebAPI
{
    public class Program
    {
        static void print(dynamic msg) => System.Console.WriteLine(msg);

        public static async Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // initialize API caller for getting online requests
            // APiHelper.InitializeClient();

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
