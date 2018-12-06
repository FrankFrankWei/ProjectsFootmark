using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccess;
using Entity;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class RegistController : BaseController
    {
        // GET: Rigest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add()
        {
            string name = Request["name"];
            string password = Request["password"];

            User user = new User { Name = name, Password = password, CreateTime = DateTime.Now, Validity = true };

            int result = 0;
            using (FootmarkContext context = new FootmarkContext())
            {
                context.User.Add(user);
                result = context.SaveChanges();
            }

            if (result <= 0)
                return View("Error");

            //set cookie
            SetAuthCookie($"{name}&{password}");
            return Redirect("~/Home");
        }
    }
}