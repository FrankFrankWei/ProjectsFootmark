/******************************************************************
** auth: wei.huazhong
** date: 12/4/2018 11:14:38 AM
** desc:
******************************************************************/

using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Filters
{
    public class AuthAttribute : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var isSkipAuth = filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), false);
            if (!isSkipAuth)
            {
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

                FootmarkContext db = new FootmarkContext();
                bool isValid = db.User.Any(m => m.Name == name && m.Password == password);
                if (!isValid)
                {
                    filterContext.Result = new RedirectResult("~/Login");
                    return;
                }
            }
        }
    }
}
