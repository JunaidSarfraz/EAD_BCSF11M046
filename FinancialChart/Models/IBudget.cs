using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChart.Models
{
    public interface IBudget
    {
        List<Budget> getAllBudgets(int id);

        void AddBudgetFromFile(string path, int p);
        void unSlect(int Bid,int Uid);
        void Slect(int Bid,int uid);
        void DeleteBudget(int id);
        void SaveBudget(Budget b,String catagories, String ranges);
    }
}
