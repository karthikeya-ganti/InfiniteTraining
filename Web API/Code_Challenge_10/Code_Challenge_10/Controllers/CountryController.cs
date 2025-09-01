using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Code_Challenge_10.Models;

namespace Code_Challenge_10.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {
        static List<Country> countrylist = new List<Country>()
        {
            new Country{CountryId=1, CountryName= "India", CountryCapital="Delhi" },
            new Country{CountryId=2, CountryName= "Sri Lanka", CountryCapital="Colombo" },
            new Country{CountryId=3, CountryName= "Japan", CountryCapital="Tokyo" }
        };

        //GetAll
        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> Get()
        {
            return countrylist;
        }

        //GetByID
        [HttpGet]
        [Route("ById")]
        public IHttpActionResult GetCountryNameById(int id)
        {
            string cname = countrylist.Where(c => c.CountryId == id).SingleOrDefault()?.CountryName;

            if (cname == null)
            {
                return NotFound();
            }
            return Ok(cname);
        }

        //PostAllFromBody
        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostAll([FromBody] Country country)
        {
            countrylist.Add(country);
            return countrylist;
        }

        //PostFromUri
        [HttpPost]
        [Route("countryPost")]
        public IEnumerable<Country> CountryPost([FromUri] int Id, string name, string capital)
        {
            Country Country = new Country();
            Country.CountryId = Id;
            Country.CountryName = name;
            Country.CountryCapital = capital;
            countrylist.Add(Country);
            return countrylist;
        }

        //PutUpdateFromUri
        [HttpPut]
        [Route("updCountry")]
        public Country Put(int id, [FromUri] string name, [FromUri] string capital)
        {
            var cList = countrylist[id - 1];
            cList.CountryId = id;
            cList.CountryName = name;
            cList.CountryCapital = capital;
            return cList;
        }

        //PutNewFromBody
        [HttpPut]
        [Route("newput")]
        public IEnumerable<Country> Put(int id, [FromBody] Country c)
        {
            countrylist[id - 1] = c;
            return countrylist;
        }

        //DeleteWithId
        [HttpDelete]
        [Route("delCountry")]
        public IEnumerable<Country> Delete(int id)
        {
            countrylist.RemoveAt(id - 1);
            return countrylist;
        }
    }
}
