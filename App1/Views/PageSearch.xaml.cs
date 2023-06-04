using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{

    public partial class PageSearch : ContentPage
    {
        public PageSearch()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource =  await App.CollegeDB.GetStudentsAsync();

            base.OnAppearing();
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        static string CheckUser(string user)
        {
            string message = "";

            if (user == null)
            {
                message = "Поле для ввода имени не может быть пустым.";
            }
            else
            {
                foreach (char symbol in user)
                {
                    if (!char.IsLetter(symbol))
                    {
                        message = "Поле имя может содержать только буквы";
                        break;
                    }
                }
            }
            return message;
        }
    }
}