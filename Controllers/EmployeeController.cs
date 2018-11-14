using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;

namespace hr_201_file.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        //
        // GET: /Employee/
        public ActionResult Index()
        {
            Employee emp = db.Employees.First();
            JobCategory jobcategory = db.JobCategories.Single(x => x.JobCategoryId == emp.JobCategoryId);

            ViewBag.jobCategory = jobcategory.Description;

            return View(db.Employees.First());
        }
	}
}