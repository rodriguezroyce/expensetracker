using ExpenseTrackerApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ExpenseTrackerApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}