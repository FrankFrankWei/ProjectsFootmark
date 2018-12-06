using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            string name = Request["name"];
            string password = Request["password"];

            FootmarkContext db = new FootmarkContext();
            bool isValid = db.User.Any(m => m.Name == name && m.Password == password);
            if (!isValid)
                return Redirect("~/Regist");

            SetAuthCookie($"{name}&{password}");
            return Redirect("~/Home");
        }
    }
}