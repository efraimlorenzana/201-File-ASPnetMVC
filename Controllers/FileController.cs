using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using hr_201_file.Common;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.PdfViewer;
using System.Drawing;

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

        public ActionResult New_Record(string search, int? page, int folder_id)
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

            string[] extensions = db.FileExtensions.Where(e => e.isAccepted == true)
                                        .Select(x => x.File_Extns).ToArray();

            ViewBag.extensions = extensions;

            return View(employees.ToPagedList(page ?? 1, 100));
        }

        public ActionResult View(int id)
        {
            FileContents file = db.FileContents.Single(x => x.id == id);

            string file_ext = Path.GetExtension(file.file_path);

            string filename = "View-" + DateTime.Now.ToShortDateString().Replace("/", "") + "-" +
                              DateTime.Now.ToShortTimeString().Replace(":", "")
                                                              .Replace(" ", "") + ".jpg";

            switch (file_ext)
            {
                case ".PDF":
                    PdfDocument pdf_file = new PdfDocument();
                    pdf_file.LoadFromFile(file.file_path);
                    Image pdf_to_img = pdf_file.SaveAsImage(0, PdfImageType.Bitmap);
                    pdf_to_img.Save(Path.Combine(Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY), filename));

                    @ViewBag.pdf = Path.Combine(Constant.VIEW_UPLOADED_FILES_DIRECTORY, filename);

                    break;
                default: break;
            }

            return View();
        }
    }


}
