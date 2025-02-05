using MVCCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN p)
        {
            CVdbEntities db = new CVdbEntities();
            var userinfo = db.TBL_ADMIN.FirstOrDefault(x => x.Username == p.Username && x.Passwd == p.Passwd);
            if (userinfo != null) {
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["Username"] = userinfo.Username.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}