using App1.Models;
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
    public partial class GetLists : ContentPage
    {
        public GetLists()
        {
            InitializeComponent();
        }

        private void GetFacultiesButton(object sender, EventArgs e)
        {           
            Navigation.PushAsync(new Faculties());
        }

        private void GetGroupsButton(object sender, EventArgs e)
        {           
            Navigation.PushAsync(new Groups());
        }

        private void GetStudentsButton(object sender, EventArgs e)
        {           
            Navigation.PushAsync(new Students());
        }

        private void GetEducatorsButton(object sender, EventArgs e)
        {           
            Navigation.PushAsync(new Educators());
        }

    }
}