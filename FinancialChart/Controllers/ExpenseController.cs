using FinancialChart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialChart.Controllers
{
    public class ExpenseController : Controller
    {
        //
        // GET: /Expense/
        IExpense exp;
        public ExpenseController(IExpense obj)
        {
            exp = obj;
        }
        public ActionResult AddExpense()
        {
            List<ExpenseCatagory> list = exp.getAllExpCatagoriesOfSelectedBudget((int)Session["key"]);
            return View(list);
        }
        public ActionResult SaveExpense(Expens expense)
        {
            String catName = Request["ddl_cat"];
            exp.saveExpense(expense,catName,(int)Session["key"]);
            return Redirect("/DashBoard/Expenses");
        }
        public JsonResult SearchExpenses(String searchTxt)
        {
            return this.Json(exp.SearchExpenses(searchTxt),JsonRequestBehavior.AllowGet);
        }
    }
}
