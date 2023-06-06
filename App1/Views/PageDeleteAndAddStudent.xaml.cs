using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;

namespace App1
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class PageDeleteAndAddStudent : ContentPage
    {
        public Label labelOne;

        public String ItemId
        {
            set
            {
                LoadStudent(value);
            }
        }

        public PageDeleteAndAddStudent()
        {
            InitializeComponent();

            BindingContext = new Student();

            DatePicker = new DatePicker();
            {
                DatePicker.Date = DateTime.Today;
                DatePicker.MaximumDate = DateTime.Today;
            }            

        }

        private async void LoadStudent(string value)
        {
            try
            {
                int id = int.Parse(value);

                Student student = await App.CollegeDB.GetStudentAsync(id);
            }
            catch { }
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            string error = null;

            Student student = new Student();

            if (CheckUser(EntryFirstName.Text) == "") student.FirstName = EntryFirstName.Text;
            else error = $"{CheckUser(EntryFirstName.Text)}\n";

            if (CheckUser(EntryMiddleName.Text) == "") student.MiddleName = EntryMiddleName.Text;
            else error += $"{CheckUser(EntryMiddleName.Text)}\n";

            if (CheckUser(EntryLastName.Text) == "") student.LastName = EntryLastName.Text;
            else error += $"{CheckUser(EntryLastName.Text)}\n";

            if (CheckGroup(EntryGroup.Text) == "") student.Group = EntryGroup.Text;
            else error += $"{CheckGroup(EntryGroup.Text)}\n";

            student.DateOfBirth = DatePicker.Date;

            if (!string.IsNullOrEmpty(error)) DisplayAlert("Error", error, "OK");
            else {await App.CollegeDB.SaveStudentAsync(student); DisplayAlert("Info", "Student was added successfuly", "OK"); }

        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
           Student student = (Student)BindingContext;

           await App.CollegeDB.DeleteStudentAsync(student);
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        static string CheckGroup(string group)
        {
            string message = "";

            if (group == null)
            {
                message = "Поле для ввода группы не может быть пустым.";
            }
            else
            {
                foreach (char symbol in group)
                {
                    if (!char.IsLetterOrDigit(symbol) && symbol != '-')
                    {
                        message = "Поле группы может содержать только буквы, цифры, -";
                        break;
                    }
                }
            }
            return message;
        }
    }
}