//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hr_201_file.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileContents
    {
        public int id { get; set; }
        public Nullable<int> employee_number { get; set; }
        public string employee_name { get; set; }
        public Nullable<int> File201_FileCategory_id { get; set; }
        public string file_name { get; set; }
        public string file_path { get; set; }
        public Nullable<System.DateTime> timestamp { get; set; }
    
        public virtual FileCategory File201_FileCategory { get; set; }
    }
}