using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChart.Models
{
    public interface IDashBoard
    {
        List<Expens> getAllExpecesOfSelectedBudget(int userID);
        List<Expens> getAllExpeces();
    }
}
