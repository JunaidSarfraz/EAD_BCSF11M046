//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinancialChart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExpenseCatagory
    {
        public ExpenseCatagory()
        {
            this.Expenses = new HashSet<Expens>();
        }
    
        public int ExpCatId { get; set; }
        public int BID { get; set; }
        public string CatName { get; set; }
        public decimal CatRange { get; set; }
        public decimal Rangepercentage { get; set; }
        public decimal ExpensesSum { get; set; }
    
        public virtual Budget Budget { get; set; }
        public virtual ICollection<Expens> Expenses { get; set; }
    }
}
