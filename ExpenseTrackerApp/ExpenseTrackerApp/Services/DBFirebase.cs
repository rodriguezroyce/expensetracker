using ExpenseTrackerApp.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerApp.Services
{
    class DBFirebase
    {
        private JsonSerializer serializer = new JsonSerializer();
        private static DBFirebase _ServiceClientInstance;
        public static DBFirebase ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new DBFirebase();
                return _ServiceClientInstance;
            }
        }
        FirebaseClient firebase;

        public DBFirebase()
        {
            firebase = new FirebaseClient("https://expensetracker-62f01-default-rtdb.firebaseio.com/");
        }
        // insert
        public async Task<bool> ExpenseInfoRegistration(string storeName, string expenseCategory, string expenseName, string totalPrice)
        {

            var result = await firebase
                .Child("Expense").PostAsync(new Expense()
                {
                    Id = Guid.NewGuid(),
                    StoreName = storeName,
                    ExpenseCategory = expenseCategory,
                    ExpenseName = expenseName,
                    TotalPrice = totalPrice,
                    Today = DateTime.Now

                });
            if (result.Object != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // select
        public ObservableCollection<Expense> getExpense()
        {
            var expenseData = firebase
                .Child("Expense")
                .AsObservable<Expense>()
                .AsObservableCollection();
            return expenseData;
        }

        public async Task UpdateExpense(Guid id, string storeName, string expenseCategory, string expenseName, string totalPrice)
        {
            // check/indentify the record you want to update
            var toUpdate = (await firebase
                .Child("Expense").OnceAsync<Expense>()).FirstOrDefault
                (a => a.Object.Id == id);
            await firebase.Child("Expense")
                .Child(toUpdate.Key)
                .PutAsync(new Expense()
                {
                    Id = id,
                    StoreName = storeName,
                    ExpenseCategory = expenseCategory,
                    ExpenseName = expenseName,
                    TotalPrice = totalPrice,
                    Today = DateTime.Now

                });

        }
        // delete
        public async Task DeleteExpense(Guid id)
        {
            // check/indentify the record you want to update
            var toDelete = (await firebase
                .Child("Expense").OnceAsync<Expense>()).FirstOrDefault
                (a => a.Object.Id == id);
            await firebase.Child("Expense")
                .Child(toDelete.Key)
                .DeleteAsync();

        }
    }
}
