using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTrackerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseListPage : ContentPage
    {
        public ExpenseListPage()
        {
            InitializeComponent();
            BindingContext = new ExpenseViewModel();
        }
        public async void TxtAdd(Object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExpensePage());
        }

        public async void OnItemSelected(Object sender, ItemTappedEventArgs args)
        {
            var expense = args.Item as Expense;
            if (expense == null) return;
            await Navigation.PushAsync(new ExpenseDetailsPage(expense));

            lstExpense.SelectedItem = null;

        }
    }
}