using App1.Models;
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
    public partial class PageDeleteAddPrepod : ContentPage
    {
        public PageDeleteAddPrepod()
        {
            InitializeComponent();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
             string error = null;

            Educator educator = (Educator)BindingContext;

            if (CheckUser(EntryName.Text) == "") educator.Name = EntryName.Text;
            else error = $"{CheckUser(EntryName.Text)}\n";

            if (CheckFaculty(EntryFacultyNumber.Text) == "") educator.FacultyNumber = EntryFacultyNumber.Text;
            else error += $"{CheckFaculty(EntryFacultyNumber.Text)}\n";

            if (CheckWorkload(EntryWorkload.Text) == "") { educator.Workload = Convert.ToInt32(EntryWorkload.Text); if (Convert.ToInt32(EntryWorkload.Text) > 1440) educator.Bonus = 5000; }
            else error += $"{CheckWorkload(EntryWorkload.Text)}\n";           

            if (!string.IsNullOrEmpty(error)) DisplayAlert("Error", error, "OK");
            else {await App.CollegeDB.SaveEducatorAsync(educator); DisplayAlert("Info", "Student was added successfuly", "OK"); }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
             Educator educator = (Educator)BindingContext;

             await App.CollegeDB.SaveEducatorAsync(educator);
        }

        static string CheckUser(string user)
        {
            string message = "";

            if (user == null)
            {
                message = "Поле для ввода не может быть пустым.";
            }
            else
            {
                foreach (char symbol in user)
                {
                    if (!char.IsLetter(symbol))
                    {
                        message = "Поле может содержать только буквы";
                        break;
                    }
                }
            }
            return message;
        }

        static string CheckFaculty(string faculty)
        {
            string message = "";

            if (faculty == null)
            {
                message = "Поле для ввода номера специальности не может быть пустым.";
            }
            else
            {
                foreach (char symbol in faculty)
                {
                    if (!char.IsDigit(symbol) && symbol != '.')
                    {
                        message = "Поле номера специальности может содержать только цифры или точки";
                        break;
                    }
                }
            }
            return message;
        }

        static string CheckWorkload(string workload)
        {
            string message = "";

            if (workload == null)
            {
                message = "Поле нагрузки не может быть пустым.";
            }
            else
            {
                foreach (char symbol in workload)
                {
                    if (!char.IsDigit(symbol))
                    {
                        message = "Поле нагрузки может содержать тольео цифры";
                        break;
                    }
                }
            }
            return message;
        }
    }
}