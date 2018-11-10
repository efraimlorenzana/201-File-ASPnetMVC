using System;
using System.IO;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using hr_201_file.Models;
using hr_201_file.Common;
using hr_201_file.Custom_Function;

namespace FineUploader
{
    public class UploadController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        [HttpPost]
        public FineUploaderResult UploadFile(FineUpload upload, string extraParam1 = null, int extraParam2 = 0)
        {
            // asp.net mvc will set extraParam1 and extraParam2 from the params object passed by Fine-Uploader

            var dir = Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY);

            var filePath = Path.Combine(dir, upload.Filename);

            try
            {

                upload.SaveAs(filePath);


                return new FineUploaderResult(true, new { FilePath = filePath });
            }
            catch (Exception ex)
            {
                return new FineUploaderResult(false, error: ex.Message);
            }

            // the anonymous object in the result below will be convert to json and set back to the browser
            //return new FineUploaderResult(true, new { extraInformation = 12345 });
        }

        [HttpPost]
        public ActionResult Add_Files(string FullName, int EmpNo, string Folder)
        {
            string filename = string.Empty;
            string destination = string.Empty;

            string pending_file_path = Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY);
            string[] filenames = Directory.GetFiles(pending_file_path);

            FileCategory category = db.FileCategories.Single(x => x.category_name == Folder);

            if (filenames.Count() == 0)
            {
                return RedirectToAction("New_Record", "File", new { folder_id = category.id });
            }

            foreach (string file_path in filenames)
            {
                filename = Path.GetFileName(file_path);
                try
                {
                    destination = Path.Combine(Server.MapPath(category.location), filename);

                    System.IO.File.Move(file_path, destination);

                    FileContents new_file = new FileContents();

                    new_file.employee_number = EmpNo;
                    new_file.employee_name = FullName;
                    new_file.File201_FileCategory_id = category.id;
                    new_file.file_name = filename;
                    new_file.file_path = file_path;
                    new_file.timestamp = DateTime.Now;

                    db.FileContents.Add(new_file);
                }
                catch
                {
                    Response.Write(CF.Alert(filename + " is already Exist in this location. try renaming the file"));
                }
            }

            db.SaveChanges();

            UploadedFileForConfirmation uploadedFiles = new UploadedFileForConfirmation();

            uploadedFiles.EmpNo = EmpNo;
            uploadedFiles.Fullname = FullName;
            uploadedFiles.Folder = Folder;
            uploadedFiles.Files = filenames;

            ViewBag.folder_id = category.id;

            return View("Confirm_Upload", uploadedFiles);
        }

        public ActionResult Add_Files()
        {
            return View();
        }
    }
}