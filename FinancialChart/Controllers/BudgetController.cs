using FinancialChart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialChart.Controllers
{
    public class BudgetController : Controller
    {
        IBudget budget;
        public BudgetController(IBudget b)
        {
            budget = b;
        }
        public ActionResult Index()
        {
            if (Session["key"] != null)
            {
                List<Budget> AllBudgets = budget.getAllBudgets((int)Session["key"]);
                return View(AllBudgets);
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }
        public ActionResult AddBudget()
        {
            if (Session["key"] != null)
                return View();
            else
                return Redirect("/Account/Login");
        }
        public ActionResult DeleteBudget(int id)
        {
            budget.DeleteBudget(id);
            return Redirect("/Budget/Index");
        }
        public ActionResult SaveBudget()
        {
            if (Session["key"] != null)
            {
                Budget b = new Budget();
                b.Name = Request["Budget_name"].ToString();
                b.Income = Int32.Parse(Request["income"]);
                b.UID = (int)Session["key"];
                String catagories = Request["catagories"].ToString();
                String ranges = Request["Ranges"].ToString();
                String StartDate = Request["SDate"].ToString();
                String EndDate = Request["EDate"].ToString();
                b.StartDate = DateTime.ParseExact(StartDate, "MM/dd/yyyy", null);
                b.EndDate = DateTime.ParseExact(EndDate, "MM/dd/yyyy", null);
                budget.SaveBudget(b,catagories,ranges);
                return Redirect("/Budget/Index");
            }
            else
            {
                return Redirect("/Account/Login");
            }
        }
        public ActionResult BudgetFromFile(HttpPostedFileBase Bfile)
        {
            //Write the code here to upload Budget File.
            var fileName = Path.GetFileName(Bfile.FileName);
            var path = Path.Combine(Server.MapPath("~/Files"), fileName);
            Bfile.SaveAs(path);

            //Now Fill Up the budget Object
            budget.AddBudgetFromFile(path,(int)Session["key"]);
            return Redirect("/Budget/Index");
        }
        public ActionResult Unslect(int id)
        {
            budget.unSlect(id,(int)Session["key"]);
            return Redirect("/Budget/Index");
        }
        public ActionResult slect(int id)
        {
            budget.Slect(id,(int)Session["key"]);
            return Redirect("/Budget/Index");
        }
    }
}
