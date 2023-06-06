using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Groups : ContentPage
    {
        public Groups()
        {
            InitializeComponent();

            listView = new ListView();
        }

        protected override async void OnAppearing()
        {
            listView.ItemsSource =  await App.CollegeDB.GetStudentsAsync();

            base.OnAppearing();
        }   
    }
}