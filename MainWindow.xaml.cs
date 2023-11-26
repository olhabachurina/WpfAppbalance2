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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppbalance2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            Expense newExpense = new Expense
            {
                Name = _viewModel.NewExpenseName,
                Amount = _viewModel.NewExpenseAmount,
                Date = _viewModel.NewExpenseDate
            };

            _viewModel.Expenses.Add(newExpense);
            _viewModel.Balance -= newExpense.Amount;
            _viewModel.NewExpenseName = "";
            _viewModel.NewExpenseAmount = 0;
            _viewModel.NewExpenseDate = DateTime.Now;
        }

        private void DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
           
            Expense selectedExpense = expensesListBox.SelectedItem as Expense;
            if (selectedExpense != null)
            {
                _viewModel.Balance += selectedExpense.Amount;
                _viewModel.Expenses.Remove(selectedExpense);
            }
        }

        private void EditExpense_Click(object sender, RoutedEventArgs e)
        {
            
            Expense selectedExpense = expensesListBox.SelectedItem as Expense;
            if (selectedExpense != null)
            {
                
                ExpenseEditWindow editWindow = new ExpenseEditWindow(selectedExpense);

               
                editWindow.Owner = this;

                
                bool? result = editWindow.ShowDialog();

                
                if (result == true)
                {
                    
                    _viewModel.Balance += selectedExpense.Amount;
                    _viewModel.Balance -= editWindow.EditedExpense.Amount;

                    
                    int index = _viewModel.Expenses.IndexOf(selectedExpense);
                    _viewModel.Expenses[index] = editWindow.EditedExpense;
                }
            }
        }
    

        private void ExpensesListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            Expense selectedExpense = expensesListBox.SelectedItem as Expense;
            if (selectedExpense != null)
            {
                _viewModel.NewExpenseName = selectedExpense.Name;
                _viewModel.NewExpenseAmount = selectedExpense.Amount;
                _viewModel.NewExpenseDate = selectedExpense.Date;

              
                editExpenseButton.IsEnabled = true;
            }
            else
            {
                
                editExpenseButton.IsEnabled = false;
            }
        }
        
       
    }
}