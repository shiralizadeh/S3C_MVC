using S3C_MVC.Models.Public;
using S3C_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace S3C_MVC.Controllers
{
    public class AccountController : Controller
    {
        UsersServices usersServices = new UsersServices();

        // GET: Login
        public ActionResult Login()
        {
            ViewBag.Title = "ورود به سایت";

            var loginStatus = new LoginStatus();

            loginStatus.IsSuccess = null;

            return View(loginStatus);
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var loginStatus = new LoginStatus();

            if (usersServices.Auth(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, false);
                var url = Request.QueryString["ReturnUrl"] ?? "/";

                return Redirect(url);
            }
            else
            {
                loginStatus.IsSuccess = false;
                loginStatus.Message = "نام کاربری یا کلمه ی عبور نادرست است.";
            }

            return View(loginStatus);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("/Account/Login");
        }
    }
}