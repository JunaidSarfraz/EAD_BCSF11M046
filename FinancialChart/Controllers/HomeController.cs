using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialChart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Features()
        {
            @ViewBag.Title = "Features";
            return View();
        }
        public ActionResult Budget()
        {
            @ViewBag.Title = "Budget";
            return View();
        }
        public ActionResult Expenses()
        {
            @ViewBag.Title = "Expenses";
            return View();
        }
        public ActionResult Alerts()
        {
            @ViewBag.Title = "Alerts";
            return View();
        }
        public ActionResult Budget_File()
        {
            @ViewBag.Title = "Budget File Uploading";
            return View();
        }
        public ActionResult About_Us()
        {
            @ViewBag.Title = "About Us";
            return View();
        }
    }
}