/******************************************************************
** auth: wei.huazhong
** date: 12/4/2018 11:48:19 AM
** desc:
******************************************************************/

using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected int UserID { get; set; }
        protected string UserName { get; set; }

        public void SetAuthCookie(string userdata)
        {
            var ticket = new FormsAuthenticationTicket(1, "footmark", DateTime.Now, DateTime.Now.AddDays(30), false, userdata);
            var authTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie("footmark", authTicket));
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isSkipAuth = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (isSkipAuth)
                return;

            var cookie = filterContext.HttpContext.Request.Cookies["footmark"];
            if (cookie == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            string[] auth = ticket.UserData.Split('&');
            if (auth.Length < 2 || ticket.Expired)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }

            var name = auth[0];
            var password = auth[1];

            User user = null;
            using (FootmarkContext db = new FootmarkContext())
            {
                user = db.User.Where(m => m.Name == name && m.Password == password).FirstOrDefault();
            }

            if (user == null)
            {
                filterContext.Result = new RedirectResult("~/Login");
                return;
            }

            UserID = user.ID;
            UserName = user.NickName ?? user.Name;
            var nameSession = HttpContext.Session["footmarkusername"];
            if (nameSession == null)
                HttpContext.Session["footmarkusername"] = UserName;
        }
    }
}
