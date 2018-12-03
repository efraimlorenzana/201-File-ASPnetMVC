using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_201_file.Models
{
    public class EmployeeModel
    {
        public List<FileContents> files { get; set; }
        public Employee employee { get; set; }
    }
}