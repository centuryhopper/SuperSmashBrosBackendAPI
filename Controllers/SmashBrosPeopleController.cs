using System;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebAPI.Data;
using System.Linq;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Controllers
{
    // api/SmashBrosPeople
    [Route("api/[controller]")]
    [ApiController]
    public class SmashBrosPeopleController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        // dependency injection
        public SmashBrosPeopleController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPeoples()
        {
            return Ok(db?.SmashBrosModels?.ToList());
        }

        // can post one smashbrospeoplemodel object or a list of objects
        // [HttpPost]
        // public async Task<IActionResult> AddSmashBrosPerson([FromBody] SmashBrosPeopleModel s)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return new JsonResult("Error while creating new smash bros person(s)");
        //     }

        //     db.SmashBrosModels.Add(s);
        //     await db.SaveChangesAsync();

        //     return new JsonResult("The smash bros person(s) was created successfully");
        // }

        [HttpPost]
        public async Task<IActionResult> AddSmashBrosPerson([FromBody] List<SmashBrosPeopleModel> s)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error while creating new smash bros person(s)");
            }

            if (s is List<SmashBrosPeopleModel>)
            {
                int n = s.Count;
                for (int i = 0; i < n; ++i)
                {
                    db.SmashBrosModels.Add(s[i]);
                }
            }
            await db.SaveChangesAsync();

            return new JsonResult("The smash bros person(s) was created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSmashBrosPerson([FromRoute] int id, [FromBody] SmashBrosPeopleModel s)
        {
            // star wars people models currently don't have an id
            // so we may need to add one later if put requests throw errors that
            // don't make sense
            if (s == null || id != s.id)
            {
                return new JsonResult("smash bros person was not found");
            }
            else
            {
                db.SmashBrosModels.Update(s);
                await db.SaveChangesAsync();
                return new JsonResult("smash bros person was updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmashBrosPerson([FromRoute] int id)
        {
            var findStarWarsPerson = await db.SmashBrosModels.FindAsync(id);
            if (findStarWarsPerson == null)
            {
                return NotFound();
            }
            else
            {
                db.SmashBrosModels.Remove(findStarWarsPerson);
                await db.SaveChangesAsync();
                return new JsonResult("smash bros person was deleted successfully");
            }
        }

        public static async Task<SmashBrosPeopleModel> FetchPeopleFromOnline(int id = 0)
        {
            string url;
            url = id > 0 ? String.Format("http://swapi.dev/api/people/{0}/", id) :
            String.Format("http://swapi.dev/api/people/");

            using (HttpResponseMessage response = await APiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // takes data in as json and converts it to the given type
                    // in this case, it's StarWarsSpeciesModel
                    SmashBrosPeopleModel peopleModel = await response.Content.ReadAsAsync<SmashBrosPeopleModel>();

                    return peopleModel;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}