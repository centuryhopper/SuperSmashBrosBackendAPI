
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI.Models
{

    // Model for GET & POST requests

    // keyless means this object cannot and will not have a primary key
    // [Keyless]

    public class SmashBrosPeopleModel
    {
        // must have get and set when declaring

        // create a migration: dotnet ef migrations add [name]

        // add model to database: dotnet ef database update [name of your migration]

        // primary key
        [Key] public int id { get; set; }
        public string name { get; set; }
        public string final_smash { get; set; }
        public string gender { get; set; }
        public string appears_in { get; set; }
        public string console_of_origin { get; set; }
        public string universe { get; set; }
        public string species { get; set; }
        public string home_world { get; set; }
    }
}
