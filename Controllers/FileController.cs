using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using PagedList;
using PagedList.Mvc;

namespace hr_201_file.Controllers
{
    
    public class FileController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        //
        // GET: /File/
        public ActionResult FileManager()
        {
            List<Folder> folders = new List<Folder>();
            foreach (FileCategory fileCategory in db.FileCategories.ToList())
            {
                Folder folder = new Folder();
                folder.Name = fileCategory.category_name;
                folder.Code = fileCategory.id;

                folders.Add(folder);
            }

            return View(folders);
        }

        public ActionResult New_Record(string search, int? page,int folder_id)
        {
            //Populate Employees List
            var employees = db.Employees.AsQueryable();
            int EmpNo;

            bool isEmpNo = int.TryParse(search, out EmpNo);
            if (isEmpNo)
            {
                employees = employees.Where(emp => emp.EmpNo == EmpNo || search == null)
                                 .OrderBy(x => x.FullName);
            }
            else
            {
                employees = employees.Where(emp => emp.FullName.Contains(search) || search == null)
                                 .OrderBy(x => x.FullName);
            }

            ViewBag.Folder = db.FileCategories.Single(x => x.id == folder_id).category_name;

            return View(employees.ToPagedList(page ?? 1, 100));
        }

        public JsonResult AutoComplete(string term)
        {
            List<string> Names = db.Employees.Where(emp => emp.FullName.Contains(term))
                                   .OrderBy(x => x.FullName)
                                   .Select(y => y.FullName).ToList();

            return Json(Names, JsonRequestBehavior.AllowGet);
        }
	}


}
    