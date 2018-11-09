using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace hr_201_file.Models
{
    [MetadataType(typeof(FileContentsMetadata))]
    public partial class FileContents {}
    public class FileContentsMetadata
    {
        public int id { get; set; }

        [DisplayName("Employee Name")]
        public string employee_name { get; set; }

        [DisplayName("Category")]
        public Nullable<int> File201_FileCategory_id { get; set; }

        [DisplayName("Filename")]
        public string file_name { get; set; }

        [DisplayName("Path")]
        public string file_path { get; set; }
    }

    public class UploadedFileForConfirmation
    {
        public int EmpNo { get; set; }
        public string Fullname { get; set; }
        public string Folder { get; set; }
        public string[] Files { get; set; }

        public List<string> Filenames(string[] Files)
        {
            List<string> populatedFilename = new List<string>();
            foreach (var filename in Files)
            {
                populatedFilename.Add(Path.GetFileName(filename));
            }

            return populatedFilename;
        }
    }
}