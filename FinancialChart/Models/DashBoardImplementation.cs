using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialChart.Models
{
    public class DashBoardImplementation : IDashBoard
    {
        public List<Expens> getAllExpecesOfSelectedBudget(int userID)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User u = db.Users.Find(userID);
            List<Expens> list = new List<Expens>();
            foreach (Budget b in u.Budgets)
            {
                if (b.isCurrent == true)
                    list = b.Expenses.ToList();
            }
            return list;
        }
        public List<Expens> getAllExpeces()
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            List<Expens> list = new List<Expens>();
            list = db.Expenses.ToList();
            return list;
        }
    }
}