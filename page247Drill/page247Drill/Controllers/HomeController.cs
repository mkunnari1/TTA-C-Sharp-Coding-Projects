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
                    var customer = new Customer();
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
                }
            }

            return View("Quote");
        }
        public ActionResult Quote( int id, string firstName, string lastName, string emailAddress, string birthday, int carYear,
            string carMake, string carModel, string dui, int tickets, string coverage)
        {
            
            return View();
        }

    }
}