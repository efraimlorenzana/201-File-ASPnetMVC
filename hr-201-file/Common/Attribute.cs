using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hr_201_file.Models;
using System.Web.Helpers;

namespace hr_201_file.Common
{
    public class Logged_User : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                string hash_id = HttpContext.Current.Request.Cookies["_userToken_"].Value;

                DatabaseContext db = new DatabaseContext();
                foreach (int id in db.Superusers.Select(x => x.id).ToList())
                {
                    bool isUser = Crypto.VerifyHashedPassword(hash_id, id.ToString());

                    if (isUser)
                    {
                        Superuser su = db.Superusers.Single(u => u.id == id);
                        User user = db.Users.Single(x => x.ADID == su.user_ADID);

                        filterContext.Controller.ViewBag.Name = user.UserName;
                        filterContext.Controller.ViewBag.UserType = su.UserType.title;
                    }
                }
            }
            catch
            {
                filterContext.Result = new RedirectToRouteResult
                    (
                        new System.Web.Routing.RouteValueDictionary
                        {
                            {"controller","Account"},{"action","Login"}
                        }
                    );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}