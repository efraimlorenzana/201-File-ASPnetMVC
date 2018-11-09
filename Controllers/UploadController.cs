using System;
using System.IO;
using System.Web.Mvc;
using hr_201_file.Models;
using hr_201_file.Common;

namespace FineUploader
{
    public class UploadController : Controller
    {

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
        public ActionResult Confirm_Upload(string FullName, int EmpNo, string Folder)
        {
            string pending_file_path = Server.MapPath(Constant.UPLOADED_FILES_DIRECTORY);
            string[] filenames = Directory.GetFiles(pending_file_path);

            UploadedFileForConfirmation uploadedFiles = new UploadedFileForConfirmation();

            uploadedFiles.EmpNo = EmpNo;
            uploadedFiles.Fullname = FullName;
            uploadedFiles.Folder = Folder;
            uploadedFiles.Files = filenames;

            return View(uploadedFiles);
        }

        public ActionResult Add_Files()
        {
            return View();
        }
    }
}