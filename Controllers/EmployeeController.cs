using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using hr_201_file.Common;
using System.IO;

namespace hr_201_file.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        //
        // GET: /Employee/
        public ActionResult Index(string search)
        {
            /// Empty UPLOADED Folder
            string pending_file_path = Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY);
            string[] Files = Directory.GetFiles(pending_file_path);

            if (Files.Count() > 0)
            {
                foreach (string file in Files)
                {
                    System.IO.File.Delete(file);
                }
            }


            Employee emp = new Employee();

            if (string.IsNullOrEmpty(search))
            {
                emp = db.Employees.First();
            }
            else
            {
                try
                {
                    int EmpNo;
                    bool isEmpNo = int.TryParse(search, out EmpNo);

                    if (isEmpNo)
                        emp = db.Employees.Single(e => e.EmpNo == EmpNo);
                    else
                        emp = db.Employees.Single(e => e.FullName == search);
                }
                catch
                {
                    return RedirectToAction("NotFound", new { name = search });
                }
            }

            JobCategory jobcategory = db.JobCategories.Single(x => x.JobCategoryId == emp.JobCategoryId);

            string userImage = Path.Combine(Server.MapPath(Constant.EMPLOYEE_PICTURE_DIRECTORY), emp.EmpNo + ".jpg");

            if (System.IO.File.Exists(userImage))
            {
                ViewBag.Picture = Path.Combine(Constant.EMPLOYEE_PICTURE_DIRECTORY, emp.EmpNo + ".jpg");
            }
            else
            {
                if (emp.Gender == "MALE")
                    ViewBag.Picture = Constant.GLOBAL_IMAGES_MALE;
                else
                    ViewBag.Picture = Constant.GLOBAL_IMAGES_FEMALE;

            }


            ViewBag.jobCategory = jobcategory.Description;
            ViewBag.fileCategory = db.FileCategories.ToList();

            return View(emp);
        }

        public ActionResult Employee_Records(int folder_id, int EmpNo)
        {
            List<FileContents> files = db.FileContents.Where(x => x.File201_FileCategory_id == folder_id && x.employee_number == EmpNo).ToList();
            return View(files);
        }

        public ActionResult NotFound(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        public JsonResult autocomplete(string term)
        {
            List<string> Names = new List<string>();
            int EmpNo;
            bool isEmpNo = int.TryParse(term, out EmpNo);

            if (isEmpNo)
            {
                Names = db.Employees.Where(e => e.EmpNo == EmpNo)
                                    .OrderBy(y => y.FullName)
                                    .Select(x => x.FullName).ToList();
            }
            else
            {
                Names = db.Employees.Where(e => e.FullName.Contains(term))
                                    .OrderBy(y => y.FullName)
                                    .Select(x => x.FullName).ToList();
            }

            return Json(Names, JsonRequestBehavior.AllowGet);
        }
    }
}