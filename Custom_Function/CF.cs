using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hr_201_file.Custom_Function
{
    public class CF
    {
        public static string Alert(string Message)
        {
            return "<sript>" +
                    Message +
                   "</script>";
        }
    }
}