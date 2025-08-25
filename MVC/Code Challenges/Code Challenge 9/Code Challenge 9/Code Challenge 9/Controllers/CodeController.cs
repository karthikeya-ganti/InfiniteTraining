using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_Challenge_9.Models;

namespace Code_Challenge_9.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        // 1. First action method should return all customers residing in Germany
        public ActionResult GetGermanyCustomers()
        {
            string country = "Germany";
            List<Customer> germanylist = (from c in db.Customers
                                          where c.Country == country
                                          orderby c.CustomerID
                                          select c).ToList();
            return View(germanylist);
        }

        // 2. Second action method should return customer details with an orderId==10248

        public ActionResult GetCustomerByOrderId()
        {
            int orderid = 10248;
            List<Customer> customerbyorder = (from c in db.Customers
                                              join o in db.Orders on c.CustomerID equals o.CustomerID
                                              where o.OrderID == orderid
                                              orderby c.CustomerID
                                              select c).ToList();
            return View(customerbyorder);
        }
    }
}