using CVPortal.DBModel;
using CVPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace CVPortal.Controllers
{
    public class AccountController : Controller
    {
        private HrPayrollEntities objHrPayrollEntities = new HrPayrollEntities();
        // GET: Account
        public ActionResult Register()
        {
            CVPortalUsers objCVPortalUsers = new CVPortalUsers();
            return View(objCVPortalUsers);
        }

        [HttpPost]
        public ActionResult Register(CVPortalUsers objCVPortalUsers)
        {
            if (ModelState.IsValid)
            {
                bool isDuplicate = objHrPayrollEntities.tblCVPortalUsers.Any(users => users.UserEmail == objCVPortalUsers.UserEmail);
                if (isDuplicate)
                {
                    string error = string.Format(@"{0} is already registered!", objCVPortalUsers.UserEmail);
                    objCVPortalUsers = new CVPortalUsers();
                    objCVPortalUsers.ErrorMessage = error;
                }
                else
                {
                    tblCVPortalUser objtblCVPortalUser = new tblCVPortalUser();

                    objtblCVPortalUser.UserName = objCVPortalUsers.UserName;
                    objtblCVPortalUser.UserEmail = objCVPortalUsers.UserEmail;
                    objtblCVPortalUser.UserPassword = Crypto.Hash(objCVPortalUsers.UserPassword);
                    objtblCVPortalUser.IsActive = 1;
                    objtblCVPortalUser.CreateDate = DateTime.Now;

                    objHrPayrollEntities.tblCVPortalUsers.Add(objtblCVPortalUser);
                    objHrPayrollEntities.SaveChanges();

                    objCVPortalUsers = new CVPortalUsers();
                    objCVPortalUsers.SuccessMessage = string.Format(@"{0} is successfully registered!", objtblCVPortalUser.UserName);
                }
            }

            return View(objCVPortalUsers);
        }
        public ActionResult Login()
        {
            CVPortalLogin objCVPortalLogin = new CVPortalLogin();
            return View(objCVPortalLogin);
        }
        [HttpPost]
        public ActionResult Login(CVPortalLogin objCVPortalLogin)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = Crypto.Hash(objCVPortalLogin.UserPassword);
                var user = objHrPayrollEntities.tblCVPortalUsers.FirstOrDefault(users => users.UserEmail == objCVPortalLogin.UserEmail && users.UserPassword == hashedPassword);
                if (user == null)
                {
                    ModelState.AddModelError("Error", "Email or Password is not matching!");
                    string error = "Email or Password is not matching!";
                    objCVPortalLogin = new CVPortalLogin();
                    objCVPortalLogin.ErrorMessage = error;
                }
                else if (user != null && user.IsActive == 0)
                {
                    ModelState.AddModelError("Error", "Contact the administrator to obtain permission!");
                    string error = "Contact the administrator to obtain permission!";
                    objCVPortalLogin = new CVPortalLogin();
                    objCVPortalLogin.ErrorMessage = error;
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, true);
                    HttpCookie cookie = new HttpCookie("CVPortal");
                    cookie["UserEmail"] = user.UserEmail;
                    cookie["UserPassword"] = user.UserPassword;
                    cookie.Expires = DateTime.Now.AddDays(7);
                    HttpContext.Response.Cookies.Add(cookie);

                    Session["objUser"] = user;
                    Session["UserName"] = user.UserName;
                    Session["UserEmail"] = user.UserEmail;
                    objCVPortalLogin = new CVPortalLogin();
                    objCVPortalLogin.SuccessMessage = string.Format(@"Welcome {0} to CV Portal of PlayOn 24!", user.UserName);
                    return RedirectToAction("Home", "Home");
                }
            }

            return View(objCVPortalLogin);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}