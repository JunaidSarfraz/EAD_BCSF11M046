using FinancialChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialChart.Controllers
{
    public class AccountController : Controller
    {
        IAccount account;
        public AccountController(IAccount acc)
        {
            account = acc;
        }

        MoneyManagementEntities2 db = new MoneyManagementEntities2();
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Authenticate(User u)
        {
            int id = account.Authenticate(u);
            if (id == -1)
            {
                return Redirect("/Account/Login");
            }
            else
            {
                Session["key"] = id;
                Session.Timeout = 20;
                return Redirect("/DashBoard/Index");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult SaveUser(User u)
        {
            if (u.Email == null)
            {
                //Error Reporting
                return Redirect("/Account/SignUp");
            }
            bool saved = account.SaveUser(u);
            if (saved == true)
            {
                return Redirect("/Account/Login");
            }
            else
            {
                //User Already Exists... Error reporting
                return Redirect("/Account/SignUp");
            }
        }
        public ActionResult LogOut()
        {
            if (Session["key"] != null)
            {
                Session["Key"] = null;
            }
            return Redirect("/Home/Index");
        }
        public ActionResult Delete()
        {
            if (Session["key"] != null)
            {
                //Delete logged in user whose id is present in Session["key"]
                account.Delete((int)Session["key"]);
            }
            return Redirect("/Home");
        }
        public ActionResult UserProfile()
        {
            if (Session["key"] != null)
            {
                User u = account.getUser((int)Session["key"]);
                return View(u);
            }
            return Redirect("/Account/Login");
        }
        public ActionResult EditProfile()
        {
            if (Session["key"] != null)
            {
                User u = account.getUser((int)Session["key"]);
                return View(u);
            }
            return View("/Account/Login");
        }
        public ActionResult SaveEditProfile(User u)
        {
            if (Session["key"] != null)
            {
                account.SaveEditProfile(u,(int)Session["key"]);
                return Redirect("/Account/UserProfile");
            }
            return View("/Account/Login");
        }
        public JsonResult CheckAvailability(String email)
        {
            return this.Json(account.checkAvailability(email),JsonRequestBehavior.AllowGet);
        }
    }
}
