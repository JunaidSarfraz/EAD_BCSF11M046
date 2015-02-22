using FinancialChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialChart.Controllers
{
    public class DashBoardController : Controller
    {
        IDashBoard DashBoard;
        public DashBoardController(IDashBoard obj)
        {
            DashBoard = obj;
        }
        public ActionResult Index()
        {
            if (Session["key"] == null)
                return Redirect("/Account/Login");
            else
            {
                List<Expens> list = DashBoard.getAllExpecesOfSelectedBudget((int)Session["key"]);
                return View(list);
            }
        }
        public ActionResult Expenses()
        {
            if (Session["key"] == null)
                return Redirect("/Account/Login");
            else
            {
                List<Expens> list = DashBoard.getAllExpeces();
                return View(list);
            }
        }
        public ActionResult Alerts()
        {
            if (Session["key"] == null)
                return Redirect("/Account/Login");
            else
                return View();
        }
        public ActionResult Budget()
        {
            if (Session["key"] == null)
                return Redirect("/Account/Login");
            else
                return Redirect("/Budget/Index");
        }
    }
}