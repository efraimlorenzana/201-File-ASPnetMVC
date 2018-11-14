using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;

namespace hr_201_file.Areas.Administrator.Controllers
{
    public class SettingController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        //
        // GET: /Administrator/Setting/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult view_extension()
        {
            List<FileExtension> extns = db.FileExtensions.ToList();
            return View(extns);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult Create_extension()
        {
            FileExtension new_ext = new FileExtension();

            TryUpdateModel(new_ext);

            if(ModelState.IsValid) {
                db.FileExtensions.Add(new_ext);
                db.SaveChanges();
            }

            return View("view_extension", db.FileExtensions.ToList());
        }

        public ActionResult toggle_extension(bool isChecked, int ext_id)
        {
            FileExtension update_ext = db.FileExtensions.Single(x => x.id == ext_id);
            update_ext.isAccepted = isChecked;
            
            db.Entry(update_ext).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            return View("view_extension", db.FileExtensions.ToList());
        }
	}
}