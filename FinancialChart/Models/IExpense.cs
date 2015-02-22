using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChart.Models
{
    public interface IExpense
    {
        List<ExpenseCatagory> getAllExpCatagoriesOfSelectedBudget(int UserID);
        void saveExpense(Expens exp,String catName,int UserID);
        List<SearchExpense> SearchExpenses(String SearchText);
    }
}
