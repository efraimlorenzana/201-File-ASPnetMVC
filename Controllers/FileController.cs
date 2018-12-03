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
using System.Net.Mime;

namespace hr_201_file.Controllers
{

    public class FileController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        //
        // GET: /File/

        [Logged_User]
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

            ViewBag.id = file.id;

            Employee emp = db.Employees.Single(e => e.EmpNo == file.employee_number);

            string file_ext = Path.GetExtension(file.file_path);

            string filename = "View-" + DateTime.Now.ToShortDateString().Replace("/", "") + "-" +
                              DateTime.Now.ToShortTimeString().Replace(":", "")
                                                              .Replace(" ", "") + ".jpg";

            List<string> pdf_pages = new List<string>();

            switch (file_ext)
            {
                case ".PDF":
                    PdfDocument pdf_file = new PdfDocument();
                    pdf_file.LoadFromFile(file.file_path);

                    int pages = pdf_file.Pages.Count > 10 ? 10 : pdf_file.Pages.Count;

                    for (int i = 0; i < pages; i++)
                    {
                        string new_filename = "page_" + i.ToString() + "-" + filename;

                        Image pdf_to_img = pdf_file.SaveAsImage(0, PdfImageType.Bitmap);
                        pdf_to_img.Save(Path.Combine(Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY), new_filename));

                        pdf_pages.Add(Path.Combine(Constant.VIEW_UPLOADED_FILES_DIRECTORY, new_filename));
                    }
                    break;
                case ".JPG":
                    System.IO.File.Copy(file.file_path, Path.Combine(Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY), Path.GetFileName(file.file_path)));
                    pdf_pages.Add(Path.Combine(Constant.VIEW_UPLOADED_FILES_DIRECTORY, Path.GetFileName(file.file_path)));
                    break;
                default:
                    Response.Write(Custom_Function.CF.Alert("preview not available for this file. the system will start downloading the file"));

                    return RedirectToAction("Download", new { id = file.id });
            }

            ViewBag.pages = pdf_pages;

            return View(emp);
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult GET_Delete(int id)
        {
            return View(db.FileContents.Single(f => f.id == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult POST_Delete(int id)
        {
            FileContents file = db.FileContents.Single(f => f.id == id);

            if (System.IO.File.Exists(file.file_path))
            {
                System.IO.File.Delete(file.file_path);
            }

            db.FileContents.Remove(file);
            db.SaveChanges();

            return RedirectToAction("Index", "Employee", new { search = file.employee_name });
        }

        public FileResult Download(int id)
        {
            FileContents file = db.FileContents.Single(x => x.id == id);

            //if (System.IO.File.Exists(file.file_path))
            //{
            //}

            byte[] filebase = System.IO.File.ReadAllBytes(file.file_path);
            string filename = Path.GetFileName(file.file_path);

            return File(filebase, MediaTypeNames.Application.Octet, filename);

            //return RedirectToAction("NotFound", "Employee");
        }
    }
}
