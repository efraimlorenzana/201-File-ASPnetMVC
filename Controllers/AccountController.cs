using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using System.Configuration;
using System.DirectoryServices;
using hr_201_file.Common;
using System.Web.Helpers;

namespace hr_201_file.Controllers
{
    public class AccountController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public ActionResult Authentication()
        {
            Login login_details = new Login();
            TryUpdateModel(login_details);

            if (ModelState.IsValid)
            {
                //LoginInfo log = new LoginInfo();
                //log = Authenticate(login_details.username, login_details.password);

                //if (log.success)
                //{
                //    if (UserVerified(log.user.ADID))
                //        return RedirectToAction("Index", "Home");
                //}

                if (true)
                {
                    if (UserVerified("jason.aquino"))
                        return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = "login-error";
            return View();
        }

        public LoginInfo Authenticate(string username, string password)
        {
            LoginInfo loginInfo = new LoginInfo();

            loginInfo.success = false;

            string adPath = ConfigurationManager.ConnectionStrings["ADDTConn"].ToString();
            string _domain = ConfigurationManager.ConnectionStrings["ADDTDomain"].ToString();
            DirectoryEntry entry = new DirectoryEntry(adPath, _domain + "\\" + username, password);

            try
            {
                //Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                DirectorySearcher search = new DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {
                    // return false;
                }

                if (Constant.DEBUG_MODE)
                    loginInfo.user = db.Users.Single(u => u.ADID == "jason.aquino");
                else
                    loginInfo.user = db.Users.Single(u => u.ADID == username);

                loginInfo.success = true;

                loginInfo.response = (string)result.Properties["cn"][0];

                // to do: check active directory id from db
            }
            catch (Exception ex)
            {
                //handel error
                loginInfo.response = ex.Message;
            }

            return loginInfo;
        }

        public bool UserVerified(string ADID)
        {
            bool isUserAllowed = db.Superusers.Any(user => user.user_ADID == ADID);

            if (isUserAllowed)
            {
                Superuser su = db.Superusers.Single(u => u.user_ADID == ADID);
                Logged(true, su.id.ToString());
            }

            return isUserAllowed;
        }

        public void Logged(bool action, string value)
        {
            HttpCookie _user = new HttpCookie("_userToken_");
            if (action)
            {
                _user.Value = Crypto.HashPassword(value);
            }
            else
            {
                _user.Expires = DateTime.Now.AddDays(-1);
            }

            Response.Cookies.Add(_user);
        }

        public ActionResult Signout()
        {
            Logged(false, "Signout");
            return View("Login");
        }
    }
}