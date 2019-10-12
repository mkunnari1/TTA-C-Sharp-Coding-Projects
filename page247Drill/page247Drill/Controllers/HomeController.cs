using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace page247Drill.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerSignUp(string firstName, string lastName, string emailAddress, string birthday, int carYear,
            string carMake, string carModel, string dui, int tickets, string coverage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(birthday)
                || carYear < 1920 || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(dui) ||
                string.IsNullOrEmpty(coverage) || tickets < 0 )
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (InsuranceEntities1 db = new InsuranceEntities1())
                {
                    Customer customer = new Customer();
                    customer.firstName = firstName;
                    customer.lastName = lastName;
                    customer.emailAddress = emailAddress;
                    customer.birthday = Convert.ToDateTime(birthday);
                    customer.carYear = carYear;
                    customer.carMake = carMake;
                    customer.carModel = carModel;
                    customer.dui = dui;
                    customer.tickets = tickets;
                    customer.coverage = coverage;

                    db.Customers.Add(customer);
                    db.SaveChanges();

                    ViewBag.Message = customer;
                }
                int cost = 50;
                var bday = Convert.ToDateTime(birthday);
                DateTime now = DateTime.Today;
                int age = now.Year - bday.Year;
                if (bday > now.AddYears(-age)) age--;

                if (age < 25 && age > 18) cost = cost+ 25;
                if (age < 18) cost = cost +100;
                if (age > 100) cost =  cost + 25;
                if (carYear < 2000) cost =  cost + 25;
                if (carYear > 2015) cost = cost + 25;
                if (carMake.ToLower() == "porsche") cost = cost + 25;
                if (carMake.ToLower() == "porsche" && carModel.ToLower() == "911 carrera") cost = cost + 25;
                if (tickets > 0) cost = cost + (tickets * 10);
                if (dui.ToLower() == "yes") cost = cost + (cost / 4);
                if (coverage.ToLower() == "full coverage") cost = cost + (cost / 2);

                ViewBag.Message2 = cost;
            }
            
            
            return View("Quote");
        }
        
        public ActionResult Admin()
        {
            using(InsuranceEntities1 db = new InsuranceEntities1())
            {
                var quotes = db.Customers;
                var adminQuotes = new List<Customer>();
                foreach(var quote in quotes)
                {
                    var adminQuote = new Customer();
                    adminQuote.firstName = quote.firstName;
                    adminQuote.lastName = quote.lastName;
                    adminQuote.emailAddress = quote.emailAddress;
                    
                    
                }
            }
        }
    }
}