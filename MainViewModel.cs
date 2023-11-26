using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppbalance2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private decimal _balance;
        private string _newExpenseName;
        private decimal _newExpenseAmount;
        private DateTime _newExpenseDate;
        private ObservableCollection<Expense> _expenses;

        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }

        public string NewExpenseName
        {
            get { return _newExpenseName; }
            set
            {
                _newExpenseName = value;
                OnPropertyChanged(nameof(NewExpenseName));
            }
        }

        public decimal NewExpenseAmount
        {
            get { return _newExpenseAmount; }
            set
            {
                _newExpenseAmount = value;
                OnPropertyChanged(nameof(NewExpenseAmount));
            }
        }

        public DateTime NewExpenseDate
        {
            get { return _newExpenseDate; }
            set
            {
                _newExpenseDate = value;
                OnPropertyChanged(nameof(NewExpenseDate));
            }
        }

        public ObservableCollection<Expense> Expenses
        {
            get { return _expenses; }
            set
            {
                _expenses = value;
                OnPropertyChanged(nameof(Expenses));
            }
        }

        public MainViewModel()
        {
            
            Balance = 0;
            NewExpenseDate = DateTime.Now;
            Expenses = new ObservableCollection<Expense>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _isEditExpenseButtonEnabled;
        public bool IsEditExpenseButtonEnabled
        {
            get { return _isEditExpenseButtonEnabled; }
            set
            {
                _isEditExpenseButtonEnabled = value;
                OnPropertyChanged(nameof(IsEditExpenseButtonEnabled));
            }
        }
        private void AddExpense()
        {
            Expense newExpense = new Expense
            {
                Name = NewExpenseName,
                Amount = NewExpenseAmount,
                Date = NewExpenseDate
            };

            Expenses.Add(newExpense);  
            Balance -= NewExpenseAmount; 

            NewExpenseName = string.Empty;
            NewExpenseAmount = 0;
            NewExpenseDate = DateTime.Now;
        }


    }
}