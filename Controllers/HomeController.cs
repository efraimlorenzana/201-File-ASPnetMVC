using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using hr_201_file.Common;

namespace hr_201_file.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [Logged_User]
        public ActionResult Index()
        {
            return View();
        }

        [Logged_User]
        public ActionResult Dashboard()
        {
            Dashboard dashboard = new Dashboard();
            dashboard.employeesCount = db.Employees.Count();
            dashboard.filesCount = db.FileContents.Count();
            dashboard.userCount = db.Superusers.Count();

            return View(dashboard);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}