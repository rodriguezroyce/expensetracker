using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Services;
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
    public partial class ExpenseDetailsPage : ContentPage
    {
        DBFirebase services;
        Guid _id;
        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();
            BindingContext = expense;
            services = new DBFirebase();
            _id = expense.Id;
        }

        public async void BtnUpdate(object sender, EventArgs e)
        {
            await services.UpdateExpense(_id, StoreName.Text, ExpenseCategory.Text, ExpenseName.Text, TotalPrice.Text);
            await Navigation.PushAsync(new ExpenseListPage());
            await DisplayAlert("Alert", "Successfully Updated Item" + _id, "Ok");
        }

        public async void BtnDelete(object sender, EventArgs e)
        {
            await services.DeleteExpense(_id);
            await Navigation.PushAsync(new ExpenseListPage());
            await DisplayAlert("Alert", "Successfully Deleted an item" + _id, "Ok");
        }
    }
}