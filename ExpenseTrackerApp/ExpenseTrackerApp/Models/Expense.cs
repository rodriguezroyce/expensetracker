using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTrackerApp.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string StoreName { get; set; }
        public string ExpenseCategory { get; set; }
        public string ExpenseName { get; set; }
        public string TotalPrice { get; set; }
        public DateTime Today { get; set; }
    }
}
