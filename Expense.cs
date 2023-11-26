using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppbalance2
{
    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public string DisplayText => $"{Name} - {Amount:C} - {Date:d}";
    }
    
}