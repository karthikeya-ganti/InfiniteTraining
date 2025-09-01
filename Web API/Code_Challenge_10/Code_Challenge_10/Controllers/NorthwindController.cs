using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Code_Challenge_10.Models;

namespace Code_Challenge_10.Controllers
{
    [RoutePrefix("api/Northwind")]
    public class NorthwindController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();
        
        //Orders where Empid = 5
        [HttpGet]
        [ResponseType(typeof(Order))]
        [Route("getorders")]
        public IHttpActionResult GetOrders() 
        {
            var orders = db.Orders.Where(o => o.EmployeeID == 5).ToList();
            return Ok(orders);
        }

        //Customers by country
        [HttpGet]
        [ResponseType(typeof(Customer))]
        [Route("GetCustomersByCountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.sp_GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}
