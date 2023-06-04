using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageChange : ContentPage
    {
        public PageChange()
        {
            InitializeComponent();
        }

        private void ChangeButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}