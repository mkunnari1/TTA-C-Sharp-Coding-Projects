using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace page247Drill.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            using(InsuranceEntities1 db = new InsuranceEntities1())
            {
                var customers = db.Customers;
                foreach(var customer in customers)
                {
                    

                }
            }
            return View();
        }
    }
}