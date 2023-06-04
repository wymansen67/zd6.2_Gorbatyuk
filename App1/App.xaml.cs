using App1.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {       
        static CollegeDB collegeDB;

        public static CollegeDB CollegeDB
        {
            get
            {
                if (collegeDB == null)
                {
                    collegeDB = new CollegeDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CollegeDatabase.db3"));
                }
                return collegeDB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
