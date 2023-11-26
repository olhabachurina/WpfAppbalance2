using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppbalance2
{
    /// <summary>
    /// Interaction logic for ExpenseEditWindow.xaml
    /// </summary>
    public partial class ExpenseEditWindow : Window
    {
        public Expense EditedExpense { get; set; }

        public ExpenseEditWindow(Expense expense)
        {
            InitializeComponent();
            EditedExpense = new Expense { Name = expense.Name, Amount = expense.Amount, Date = expense.Date };
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
