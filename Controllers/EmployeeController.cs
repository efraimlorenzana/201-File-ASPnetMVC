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
            ViewBag.fileCategory = db.FileCategories.ToList();

            return View(db.Employees.Single(e => e.EmpNo == 13109));
        }

        public ActionResult Employee_Records(int folder_id, int EmpNo)
        {
            List<FileContents> files = db.FileContents.Where(x => x.File201_FileCategory_id == folder_id && x.employee_number == EmpNo).ToList();
            return View(files);
        }

        public JsonResult autocomplete(string term)
        {
            List<string> Names = db.FileContents.Where(e => e.employee_name.Contains(term))
                                    .OrderBy(y => y.employee_name)
                                    .Select(x => x.employee_name).ToList();

            return Json(Names, JsonRequestBehavior.AllowGet);
        }
	}
}