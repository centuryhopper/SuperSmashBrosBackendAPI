using System.Collections.Generic;
using AspNetCoreWebAPI.Models;

namespace AspNetCoreWebAPI.Services
{
    public class StarWarsPeopleService
    {
        List<SmashBrosPeopleModel> peopleLst = new List<SmashBrosPeopleModel>();

        public StarWarsPeopleService()
        {
            peopleLst = new List<SmashBrosPeopleModel>();
        }

        public List<SmashBrosPeopleModel> GetList()
        {
            // peopleLst.Add(
            //     new StarWarsPeopleModel
            //     {
            //         name="yoda",
            //         birth_year="900bby",
            //         gender="male",
            //         height="43in",
            //         eye_color="brown"
            //     }
            // );
            return peopleLst;
        }

        public SmashBrosPeopleModel GetFromList(int id) => peopleLst[id];

        /// <summary>
        ///
        /// </summary>
        /// <param name="id">the index of the value to update</param>
        /// <param name="m">the value that will be placed at the given index</param>
        public void UpdateList(int id, SmashBrosPeopleModel m) => peopleLst[id] = m;

        public void AddToPeoples(SmashBrosPeopleModel s) => peopleLst.Add(s);

        public void RemoveFromPeoples(int id) => peopleLst.RemoveAt(id);

        public bool IsEmpty => peopleLst.Count == 0;







    }
}