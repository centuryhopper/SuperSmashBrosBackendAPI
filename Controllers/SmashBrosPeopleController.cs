using System;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebAPI.Data;
using System.Linq;

namespace AspNetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmashBrosPeopleController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        // api/SmashBrosPeople
        public SmashBrosPeopleController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetPeoples()
        {
            return Ok(db?.PeopleModels?.ToList());
        }

        // can post one smashbrospeoplemodel object or a list of objects
        [HttpPost]
        public async Task<IActionResult> AddSmashBrosPerson([FromBody] SmashBrosPeopleModel s)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error while creating new smash bros person");
            }

            db.PeopleModels.Add(s);
            await db.SaveChangesAsync();

            return new JsonResult("The smash bros person was created successfully");
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
                db.PeopleModels.Update(s);
                await db.SaveChangesAsync();
                return new JsonResult("smash bros person was updated successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmashBrosPerson([FromRoute] int id)
        {
            var findStarWarsPerson = await db.PeopleModels.FindAsync(id);
            if (findStarWarsPerson == null)
            {
                return NotFound();
            }
            else
            {
                db.PeopleModels.Remove(findStarWarsPerson);
                await db.SaveChangesAsync();
                return new JsonResult("smash bros person was deleted successfully");
            }
        }




        #region local way
        // StarWarsPeopleService s;

        // public StarWarsPeopleController(StarWarsPeopleService s)
        // {
        //     this.s = s;
        // }

        // [HttpGet]
        // public ActionResult Get()
        // {
        //     if (this.s.IsEmpty)
        //     {
        //         return Ok("the list is empty");
        //     }
        //     return Ok(this.s.GetList());
        // }

        // [HttpPost]
        // public ActionResult Post(StarWarsPeopleModel s)
        // {
        //     this.s.AddToPeoples(s);
        //     return Ok("added");
        // }

        // [HttpPut]
        // public ActionResult Put(int idx, StarWarsPeopleModel m)
        // {
        //     this.s.UpdateList(idx, m);
        //     return Ok();
        // }

        // [HttpDelete("{id}")]
        // public ActionResult Delete(int idx)
        // {
        //     this.s.RemoveFromPeoples(idx);
        //     return Ok();
        // }
        #endregion

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