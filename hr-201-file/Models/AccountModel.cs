using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hr_201_file.Models
{
    public class Login
    {

        [DisplayName("Username")]
        [Required]
        public string username { get; set; }

        [DisplayName("Password")]
        [Required]
        public string password { get; set; }
    }

    public class LoginInfo
    {
        public bool success { get; set; }
        public User user { get; set; }
        public string response { get; set; }
    }
}