using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FinancialChart.Models
{
    public class BudgetImplementation : IBudget
    {
        public List<Budget> getAllBudgets(int id)
        {
            List<Budget> budgets = new List<Budget>();
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            User LoggedInUser = db.Users.Find(id);
            foreach (Budget b in LoggedInUser.Budgets)
            {
                budgets.Add(b);
            }
            return budgets;
        }
        public void AddBudgetFromFile(String path,int UserId)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            String name = sr.ReadLine();
            String StartDate = sr.ReadLine();
            String endDate = sr.ReadLine();
            String Income = sr.ReadLine();
            String ExpCatagories = sr.ReadLine();
            String ExpCatagoriesRanges = sr.ReadLine();
            
            sr.Close();
            fs.Close();
            
            Budget b = new Budget();
            b.Name = name;
            b.UID = UserId;
            b.StartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", null);
            b.EndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", null);
            b.Income = Int32.Parse(Income);
            b.isCurrent = true;

            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            Budget AlreadySelectedBudget = null;
            foreach (Budget curr in db.Budgets)
            {
                if (curr.isCurrent == true)
                    AlreadySelectedBudget = curr;
            }
            if (AlreadySelectedBudget != null)
            {
                AlreadySelectedBudget.isCurrent = false;
                db.SaveChanges();
            }
            db.Budgets.Add(b);
            db.SaveChanges();

            String [] catagories = ExpCatagories.Split(',');
            String[] catagoriesRanges = ExpCatagoriesRanges.Split(',');
            ExpenseCatagory Bcatagory = new ExpenseCatagory();
            for (int i = 0; i < catagories.Length; i++ )
            {
                Bcatagory.BID = b.BID;
                Bcatagory.CatName = catagories[i];
                Bcatagory.CatRange = Int32.Parse(catagoriesRanges[i]);
                Bcatagory.Rangepercentage = ( (Bcatagory.CatRange / b.Income) * 100 );
                Bcatagory.ExpensesSum = 0;
                db.ExpenseCatagories.Add(Bcatagory);
                db.SaveChanges();
            }
        }
        public void DeleteBudget(int id)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            Budget b = db.Budgets.Find(id);
            List<ExpenseCatagory> catagories = new List<ExpenseCatagory>();
            foreach (ExpenseCatagory c in b.ExpenseCatagories)
            {
                catagories.Add(c);
            }
            foreach (ExpenseCatagory c in catagories)
            {
                db.ExpenseCatagories.Remove(c);
            }
            db.Budgets.Remove(b);
            db.SaveChanges();
        }
        public void unSlect(int Bid,int uid)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            Budget b = db.Budgets.Find(Bid);
            b.isCurrent = false;
            db.SaveChanges();
        }
        public void Slect(int Bid,int uid)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            Budget AlreadySelectedBudget = null;
            User u = db.Users.Find(uid);
            foreach (Budget curr in u.Budgets)
            {
                if (curr.isCurrent == true)
                    AlreadySelectedBudget = curr;
            }
            if (AlreadySelectedBudget != null)
            {
                AlreadySelectedBudget.isCurrent = false;
                db.SaveChanges();
            }
            Budget B = db.Budgets.Find(Bid);
            B.isCurrent = true;
            db.SaveChanges();
        }
        public void SaveBudget(Budget b, String catagories, String ranges)
        {
            MoneyManagementEntities2 db = new MoneyManagementEntities2();
            db.Budgets.Add(b);
            db.SaveChanges();

            String[] catagoriesList = catagories.Split(',');
            String[] rangesList = ranges.Split(',');
            Budget currBudget = db.Budgets.Find(b.BID);
            for (int i = 0; i < catagoriesList.Length; i++)
            {
                ExpenseCatagory cat = new ExpenseCatagory();
                cat.BID = b.BID;
                cat.CatName = catagoriesList[i];
                cat.CatRange = Int32.Parse(rangesList[i]);
                cat.Rangepercentage = ((cat.CatRange / currBudget.Income) * 100);
                cat.ExpensesSum = 0;
                db.ExpenseCatagories.Add(cat);
                db.SaveChanges();
            }
        }
    }
}