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

        
	}
}