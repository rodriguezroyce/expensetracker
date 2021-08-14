using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExpenseTrackerApp.ViewModels
{
    class ExpenseViewModel : BindableObject
    {
        #region Field Variables
        // expense storename
        private string _StoreName;
        public string StoreName
        {
            get { return _StoreName; }
            set
            {
                _StoreName = value;
                OnPropertyChanged();
            }
        }
        // expenseCategory
        private string _ExpenseCategory;
        public string ExpenseCategory
        {
            get { return _ExpenseCategory; }
            set
            {
                _ExpenseCategory = value;
                OnPropertyChanged();
            }
        }
        // expense name
        private string _ExpenseName;
        public string ExpenseName
        {
            get { return _ExpenseName; }
            set
            {
                _ExpenseName = value;
                OnPropertyChanged();
            }
        }
        // total price
        private string _TotalPrice;
        public string TotalPrice
        {
            get { return _TotalPrice; }
            set
            {
                _TotalPrice = value;
                OnPropertyChanged();
            }


        }
        #endregion
        public ICommand RegisterExpenseInfo
        {
            get;
        }
        public ExpenseViewModel()
        {
            RegisterExpenseInfo = new Command(async () => await SetRegisterExpense());


            GetExpenseList = DBFirebase.ServiceClientInstance.getExpense();
        }
        private async Task SetRegisterExpense()
        {
            var response = await DBFirebase.ServiceClientInstance.ExpenseInfoRegistration(StoreName, ExpenseCategory, ExpenseName, TotalPrice);
            if (response == true)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "New records added!", "ok");

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Alert", "No records added!", "ok");
            }
        }
        private ObservableCollection<Expense> _expense = new ObservableCollection<Expense>();

        public ObservableCollection<Expense> GetExpenseList
        {
            get { return _expense; }
            set
            {
                _expense = value;
                OnPropertyChanged();
            }
        }
    }
}
