using AspNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AspNetCoreWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // the meat of our migrations (middle man between sql database and this project)
        public DbSet<SmashBrosPeopleModel> PeopleModels { get; set; }
    }
}
