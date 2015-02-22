using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialChart.Models
{
    public class ExpenseImplementation : IExpense
    {
        public List<ExpenseCatagory> getAllExpCatagoriesOfSelectedBudget(int UserID)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User u = db.Users.Find(UserID);
            List<ExpenseCatagory> list = new List<ExpenseCatagory>();
            foreach(Budget b in u.Budgets)
            {
                if (b.isCurrent == true)
                    list = b.ExpenseCatagories.ToList();
            }
            return list;
        }
        public void saveExpense(Expens exp,String catName,int UserID)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User u = db.Users.Find(UserID);
            Budget SelectedBudget = new Budget();
            foreach (Budget b in u.Budgets)
            {
                if (b.isCurrent == true)
                {
                    exp.BID = b.BID;
                    SelectedBudget = b;
                }
            }
            foreach(ExpenseCatagory expCat in SelectedBudget.ExpenseCatagories)
            {
                if (expCat.CatName == catName)
                {
                    exp.ExpCat = expCat.ExpCatId;
                }
            }
            db.Expenses.Add(exp);
            db.SaveChanges();
        }
        public List<SearchExpense> SearchExpenses(String SearchText)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            List<SearchExpense> SearchedExpenses = new List<SearchExpense>();
            List<Expens> all = db.Expenses.ToList();
            for (int i = 0; i < all.Count; i++ )
            {
                Expens e = all[i];
                if (e.Description.Contains(SearchText))
                {
                    SearchExpense ex = new SearchExpense();
                    ex.Amount = e.Amount;
                    ex.Description = e.Description;
                    ex.BudgetName = e.Budget.Name;
                    SearchedExpenses.Add(ex);
                    //SearchedExpenses.Add(e);
                }
            }
            return SearchedExpenses;
        }
    }
}