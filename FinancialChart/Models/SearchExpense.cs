using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinancialChart.Models
{
    public class SearchExpense
    {
        public String BudgetName { get; set; }
        public String Description { get; set; }
        public Decimal Amount { get; set; }
    }
}