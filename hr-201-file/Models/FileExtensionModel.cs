using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hr_201_file.Models
{
    public class FileExtensionMetadata
    {
        public int id { get; set; }

        [DisplayName("File Type")]
        public string File_Type { get; set; }

        [DisplayName("Extension")]
        public string File_Extns { get; set; }

        [DisplayName("Accept")]
        public bool isAccepted { get; set; }
    }

    [MetadataType(typeof(FileExtensionMetadata))]
    public partial class FileExtension { }
}